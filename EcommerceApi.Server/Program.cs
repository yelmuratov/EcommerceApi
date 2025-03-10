using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using EcommerceApi.Server.Mappings;
using EcommerceApi.Server.Interfaces.CategoryInterfaces;
using EcommerceApi.Server.Interfaces.OrderInterfaces;
using EcommerceApi.Server.Repositories.CategoryRepos;
using EcommerceApi.Server.Repositories.OrderRepos;
using EcommerceApi.Server.Services;
using EcommerceApi.Server.Interfaces.PaymentInterfaces;
using EcommerceApi.Server.Interfaces.UserInterfaces;
using EcommerceApi.Server.ProductInterfaces;
using EcommerceApi.Server.Repositories.ProductRepos;
using EcommerceApi.Server.Repositories.UserRepos;
using EcommerceApi.Server.Repositories.PaymentRepos;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Configure Entity Framework with SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register Services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });
});

var app = builder.Build();

// Enable Swagger (For API Documentation)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerce API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();