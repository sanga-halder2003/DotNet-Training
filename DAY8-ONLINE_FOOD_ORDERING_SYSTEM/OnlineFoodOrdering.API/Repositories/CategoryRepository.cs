using OnlineFoodOrdering.API.Data;
using OnlineFoodOrdering.API.Models;
using Microsoft.EntityFrameworkCore;
namespace OnlineFoodOrdering.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FoodOrderingDbContext _context;

        public CategoryRepository(FoodOrderingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
