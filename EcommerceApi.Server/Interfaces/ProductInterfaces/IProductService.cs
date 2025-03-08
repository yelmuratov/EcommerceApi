using EcommerceApi.Server.DTOs.ProductDTOs;

namespace EcommerceApi.Server.ProductInterfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO?> GetProductById(int id);
        Task<ProductDTO> CreateProduct(ProductCreateDTO productDto);
        Task<ProductDTO?> UpdateProduct(int id, ProductCreateDTO productDto);
        Task<bool> DeleteProduct(int id);
    }
}
