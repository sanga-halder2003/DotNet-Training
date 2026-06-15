using OnlineFoodOrdering.API.Models;
using OnlineFoodOrdering.API.Repositories;

namespace OnlineFoodOrdering.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<Category> AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Category name is required");
            }

            await _categoryRepository.AddCategory(category);
            return category;
        }

        public async Task<bool> UpdateCategory(int id, Category category)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(id);

            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;

            await _categoryRepository.UpdateCategory(existingCategory);

            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(id);

            if (existingCategory == null)
            {
                return false;
            }

            await _categoryRepository.DeleteCategory(existingCategory);

            return true;
        }
    }
}