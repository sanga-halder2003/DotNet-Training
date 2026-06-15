using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Repositories
{
    public interface IFoodItemRepository
    {
        Task<List<FoodItem>> GetAllFoodItems();
        Task<FoodItem?> GetFoodItemById(int id);
        Task AddFoodItem(FoodItem foodItem);
        Task UpdateFoodItem(FoodItem foodItem);
        Task DeleteFoodItem(FoodItem foodItem);

        Task<List<FoodItem>> SearchFoodItems(string name);
        Task<List<FoodItem>> GetFoodItemsByCategory(int categoryId);
    }
}