using OnlineFoodOrdering.API.Models;

namespace OnlineFoodOrdering.API.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<Category> AddCategory(Category category);
        Task<bool> UpdateCategory(int id, Category category);
        Task<bool> DeleteCategory(int id);
    }
}
