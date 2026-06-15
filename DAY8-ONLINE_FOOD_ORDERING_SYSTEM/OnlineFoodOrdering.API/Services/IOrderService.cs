using OnlineFoodOrdering.API.DTOs;

namespace OnlineFoodOrdering.API.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrder(OrderCreateDto orderCreateDto);
        Task<OrderResponseDto?> GetOrderById(int id);
        Task<bool> CancelOrder(int id);
    }
}