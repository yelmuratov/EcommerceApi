using AutoMapper;
using EcommerceApi.Server.DTOs.ProductDTOs;
using EcommerceApi.Server.Models;
using EcommerceApi.Server.ProductInterfaces;

namespace EcommerceApi.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products); // ✅ AutoMapper converts list
        }

        public async Task<ProductDTO?> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return _mapper.Map<ProductDTO>(product); // ✅ AutoMapper handles mapping
        }

        public async Task<ProductDTO> CreateProduct(ProductCreateDTO productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);
            var createdProduct = await _productRepository.AddAsync(newProduct);
            return _mapper.Map<ProductDTO>(createdProduct);
        }

        public async Task<ProductDTO?> UpdateProduct(int id, ProductCreateDTO productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            _mapper.Map(productDto, product);
            var updatedProduct = await _productRepository.UpdateAsync(product);

            return _mapper.Map<ProductDTO>(updatedProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
