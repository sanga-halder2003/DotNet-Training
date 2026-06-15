using OnlineFoodOrdering.API.DTOs;
using OnlineFoodOrdering.API.Models;
using OnlineFoodOrdering.API.Repositories;

namespace OnlineFoodOrdering.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IFoodItemRepository _foodItemRepository;

        public OrderService(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IFoodItemRepository foodItemRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _foodItemRepository = foodItemRepository;
        }

        public async Task<OrderResponseDto> CreateOrder(OrderCreateDto orderCreateDto)
        {
            var customer = await _customerRepository.GetCustomerById(orderCreateDto.CustomerId);

            if (customer == null)
                throw new Exception("Invalid customer id");

            if (orderCreateDto.Items == null || orderCreateDto.Items.Count == 0)
                throw new Exception("Order must contain at least one food item");

            decimal totalAmount = 0;
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (var item in orderCreateDto.Items)
            {
                if (item.Quantity <= 0)
                    throw new Exception("Quantity must be greater than zero");

                var foodItem = await _foodItemRepository.GetFoodItemById(item.FoodId);

                if (foodItem == null)
                    throw new Exception("Invalid food id");

                if (foodItem.IsAvailable == false)
                    throw new Exception($"{foodItem.FoodName} is not available");

                totalAmount += foodItem.Price * item.Quantity;

                orderDetails.Add(new OrderDetail
                {
                    FoodId = foodItem.FoodId,
                    Quantity = item.Quantity,
                    UnitPrice = foodItem.Price
                });
            }

            var order = new Order
            {
                CustomerId = orderCreateDto.CustomerId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = totalAmount,
                OrderDetails = orderDetails
            };

            await _orderRepository.AddOrder(order);

            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }

        public async Task<OrderResponseDto?> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);

            if (order == null)
                return null;

            return new OrderResponseDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }

        public async Task<bool> CancelOrder(int id)
        {
            var order = await _orderRepository.GetOrderById(id);

            if (order == null)
                return false;

            if (order.Status == "Delivered")
                throw new Exception("Delivered orders cannot be cancelled");

            order.Status = "Cancelled";

            await _orderRepository.UpdateOrder(order);

            return true;
        }
    }
}