using System.Diagnostics.CodeAnalysis;
using Core.Models;

namespace Core.Abstractions
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();
        Task<int> CreateOrder(Order Order);
        Task<Order> GetOrderById(int id);
        Task<int> UpdateOrder(Order Order);
        Task<int> DeleteOrder(int id);
    }
}
