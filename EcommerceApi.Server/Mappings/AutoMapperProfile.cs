using AutoMapper;
using EcommerceApi.Server.DTOs.OrderDTOs;
using EcommerceApi.Server.DTOs.PaymentDTOs;
using EcommerceApi.Server.DTOs.UserDTOs;
using EcommerceApi.Server.DTOs.ProductDTOs;
using EcommerceApi.Server.Models;
using EcommerceApi.Server.DTOs.CategoryDTOs;

namespace EcommerceApi.Server.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // 🔹 Category Mappings
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            // 🔹 Order Mappings
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();

            // 🔹 Payment Mappings
            CreateMap<Payment, PaymentDTO>().ReverseMap();

            // 🔹 User Mappings
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();

            // 🔹 Product Mappings
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
        }
    }
}
