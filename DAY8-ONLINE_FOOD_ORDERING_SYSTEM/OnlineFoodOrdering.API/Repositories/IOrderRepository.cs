using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderById(int id);
        Task<List<Order>> GetOrdersByCustomerId(int customerId);
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
    }
}