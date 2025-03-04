using Core.Abstractions;
using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<int> CreateOrder(Order Order)
        {
            var orderEntity = new OrderEntity
            {
                SenderCity = Order.SenderCity,
                SenderAddress = Order.SenderAddress,
                RecipientCity = Order.RecipientCity,
                RecipientAddress = Order.RecipientAddress,
                CargoWeight = Order.CargoWeight,
                PickupDate = Order.PickupDate,
                CreatedAt = Order.CreatedAt
            };

            await _context.Order.AddAsync(orderEntity);
            await _context.SaveChangesAsync();

            return orderEntity.Id;
        }

        public async Task<int> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id) ?? throw new InvalidOperationException("Заказ не найден");
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            var OrderEntities = await _context.Order.ToListAsync();

            return OrderEntities.Select(o => new Order
            {
                Id = o.Id,
                SenderCity = o.SenderCity,
                SenderAddress = o.SenderAddress,
                RecipientCity = o.RecipientCity,
                RecipientAddress = o.RecipientAddress,
                CargoWeight = o.CargoWeight,
                PickupDate = o.PickupDate,
                CreatedAt = o.CreatedAt
            }).ToList();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var orderEntity = await _context.Order.FindAsync(id) ?? throw new InvalidOperationException("Order not found");
            return new Order
            {
                Id = orderEntity.Id,
                SenderCity = orderEntity.SenderCity,
                SenderAddress = orderEntity.SenderAddress,
                RecipientCity = orderEntity.RecipientCity,
                RecipientAddress = orderEntity.RecipientAddress,
                CargoWeight = orderEntity.CargoWeight,
                PickupDate = orderEntity.PickupDate,
                CreatedAt = orderEntity.CreatedAt
            };
        }

        public async Task<int> UpdateOrder(Order order)
        {
            var orderEntity = await _context.Order.FindAsync(order.Id) ?? throw new InvalidOperationException("Заказ не найден");
            orderEntity.SenderCity = order.SenderCity;
            orderEntity.SenderAddress = order.SenderAddress;
            orderEntity.RecipientCity = order.RecipientCity;
            orderEntity.RecipientAddress = order.RecipientAddress;
            orderEntity.CargoWeight = order.CargoWeight;
            orderEntity.PickupDate = order.PickupDate;
            orderEntity.CreatedAt = order.CreatedAt;

            await _context.SaveChangesAsync();

            return orderEntity.Id;
        }
    }
}
