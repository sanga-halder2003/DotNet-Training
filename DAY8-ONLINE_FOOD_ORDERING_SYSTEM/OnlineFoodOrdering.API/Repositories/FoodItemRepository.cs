using Microsoft.EntityFrameworkCore;
using OnlineFoodOrdering.API.Data;
using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodOrderingDbContext _context;

        public FoodItemRepository(FoodOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<List<FoodItem>> GetAllFoodItems()
        {
            return await _context.FoodItems
                .Include(f => f.Category)
                .ToListAsync();
        }

        public async Task<FoodItem?> GetFoodItemById(int id)
        {
            return await _context.FoodItems
                .Include(f => f.Category)
                .FirstOrDefaultAsync(f => f.FoodId == id);
        }

        public async Task AddFoodItem(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodItem(FoodItem foodItem)
        {
            _context.FoodItems.Update(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodItem(FoodItem foodItem)
        {
            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FoodItem>> SearchFoodItems(string name)
        {
            return await _context.FoodItems
                .Where(f => f.FoodName.Contains(name))
                .ToListAsync();
        }

        public async Task<List<FoodItem>> GetFoodItemsByCategory(int categoryId)
        {
            return await _context.FoodItems
                .Where(f => f.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}