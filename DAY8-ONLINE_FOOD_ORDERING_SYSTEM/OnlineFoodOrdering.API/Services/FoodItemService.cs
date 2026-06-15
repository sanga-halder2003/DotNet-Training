using OnlineFoodOrdering.API.Models;
using OnlineFoodOrdering.API.Repositories;

namespace OnlineFoodOrdering.API.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FoodItemService(
            IFoodItemRepository foodItemRepository,
            ICategoryRepository categoryRepository)
        {
            _foodItemRepository = foodItemRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<FoodItem>> GetAllFoodItems()
        {
            return await _foodItemRepository.GetAllFoodItems();
        }

        public async Task<FoodItem?> GetFoodItemById(int id)
        {
            return await _foodItemRepository.GetFoodItemById(id);
        }

        public async Task<FoodItem> AddFoodItem(FoodItem foodItem)
        {
            if (string.IsNullOrWhiteSpace(foodItem.FoodName))
            {
                throw new Exception("Food name is required");
            }

            if (foodItem.Price <= 0)
            {
                throw new Exception("Price must be greater than zero");
            }

            var category = await _categoryRepository.GetCategoryById(foodItem.CategoryId);

            if (category == null)
            {
                throw new Exception("Invalid category id");
            }

            await _foodItemRepository.AddFoodItem(foodItem);
            return foodItem;
        }

        public async Task<bool> UpdateFoodItem(int id, FoodItem foodItem)
        {
            var existingFoodItem = await _foodItemRepository.GetFoodItemById(id);

            if (existingFoodItem == null)
            {
                return false;
            }

            var category = await _categoryRepository.GetCategoryById(foodItem.CategoryId);

            if (category == null)
            {
                throw new Exception("Invalid category id");
            }

            existingFoodItem.FoodName = foodItem.FoodName;
            existingFoodItem.Price = foodItem.Price;
            existingFoodItem.CategoryId = foodItem.CategoryId;
            existingFoodItem.IsAvailable = foodItem.IsAvailable;

            await _foodItemRepository.UpdateFoodItem(existingFoodItem);

            return true;
        }

        public async Task<bool> DeleteFoodItem(int id)
        {
            var existingFoodItem = await _foodItemRepository.GetFoodItemById(id);

            if (existingFoodItem == null)
            {
                return false;
            }

            await _foodItemRepository.DeleteFoodItem(existingFoodItem);

            return true;
        }

        public async Task<List<FoodItem>> SearchFoodItems(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Search name is required");

            return await _foodItemRepository.SearchFoodItems(name);
        }

        public async Task<List<FoodItem>> GetFoodItemsByCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
                throw new Exception("Invalid category id");

            return await _foodItemRepository.GetFoodItemsByCategory(categoryId);
        }
    }
}