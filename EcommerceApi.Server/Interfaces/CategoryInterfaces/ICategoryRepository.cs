using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Interfaces.CategoryInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);   
        Task<bool> DeleteAsync(int id);
    }
}
