using AutoMapper;
using EcommerceApi.Server.Interfaces.CategoryInterfaces;
using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return category;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }

            var newCategory = _mapper.Map<Category>(category);
            return await _categoryRepository.AddAsync(newCategory);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(category.Id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {category.Id} not found.");
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }

            _mapper.Map(category, existingCategory);
            return await _categoryRepository.UpdateAsync(existingCategory);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            return await _categoryRepository.DeleteAsync(id);
        }
    }
}
