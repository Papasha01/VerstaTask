using API.Contracts;
using Core.Abstractions;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IOrderRepository OrderRepository) : ControllerBase
    {
        private readonly IOrderRepository _OrderRepository = OrderRepository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll()
        {
            try
            {
                var Order = await _OrderRepository.GetAllOrder();
                var response = Order.Select(o => new OrderResponse(
                    o.Id,
                    o.SenderCity,
                    o.SenderAddress,
                    o.RecipientCity,
                    o.RecipientAddress,
                    o.CargoWeight,
                    o.PickupDate,
                    o.CreatedAt));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(int id)
        {
            try
            {
                var order = await _OrderRepository.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }

                var response = new OrderResponse(
                    order.Id,
                    order.SenderCity,
                    order.SenderAddress,
                    order.RecipientCity,
                    order.RecipientAddress,
                    order.CargoWeight,
                    order.PickupDate,
                    order.CreatedAt);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create([FromBody] OrderRequest request)
        {
            try
            {
                var (order, error) = Order.Create(
                    0,
                    request.SenderCity,
                    request.SenderAddress,
                    request.RecipientCity,
                    request.RecipientAddress,
                    request.CargoWeight,
                    request.PickupDate,
                    DateTime.UtcNow);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(new { Error = error });
                }

                var createdOrderId = await _OrderRepository.CreateOrder(order);
                var createdOrder = await _OrderRepository.GetOrderById(createdOrderId);

                var response = new OrderResponse(
                    createdOrder.Id,
                    createdOrder.SenderCity,
                    createdOrder.SenderAddress,
                    createdOrder.RecipientCity,
                    createdOrder.RecipientAddress,
                    createdOrder.CargoWeight,
                    createdOrder.PickupDate,
                    createdOrder.CreatedAt);

                return CreatedAtAction(nameof(GetById), new { id = createdOrderId }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse>> Update(int id, [FromBody] OrderRequest request)
        {
            try
            {
                var existingOrder = await _OrderRepository.GetOrderById(id);
                if (existingOrder == null)
                {
                    return NotFound();
                }

                var (updatedOrder, error) = Order.Create(
                    id,
                    request.SenderCity,
                    request.SenderAddress,
                    request.RecipientCity,
                    request.RecipientAddress,
                    request.CargoWeight,
                    request.PickupDate,
                    existingOrder.CreatedAt);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(new { Error = error });
                }

                await _OrderRepository.UpdateOrder(updatedOrder);

                var updatedOrderFromRepo = await _OrderRepository.GetOrderById(id);

                var response = new OrderResponse(
                    updatedOrderFromRepo.Id,
                    updatedOrderFromRepo.SenderCity,
                    updatedOrderFromRepo.SenderAddress,
                    updatedOrderFromRepo.RecipientCity,
                    updatedOrderFromRepo.RecipientAddress,
                    updatedOrderFromRepo.CargoWeight,
                    updatedOrderFromRepo.PickupDate,
                    updatedOrderFromRepo.CreatedAt);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingOrder = await _OrderRepository.GetOrderById(id);
                if (existingOrder == null)
                {
                    return NotFound();
                }

                await _OrderRepository.DeleteOrder(id);

                return NoContent();
            }
            catch (System.InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}