using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Services
{
    public interface IFoodItemService
    {
        Task<List<FoodItem>> GetAllFoodItems();
        Task<FoodItem?> GetFoodItemById(int id);
        Task<FoodItem> AddFoodItem(FoodItem foodItem);
        Task<bool> UpdateFoodItem(int id, FoodItem foodItem);
        Task<bool> DeleteFoodItem(int id);

        Task<List<FoodItem>> SearchFoodItems(string name);
        Task<List<FoodItem>> GetFoodItemsByCategory(int categoryId);
    }
}