using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using Net.Services.Customers;
using Net.Services.Discount;
using Net.Services.Order;
using Net.Services.Payments;
using Net.Services.Product;
using Net.Services.Shipping;
using Net.Services.WareHouse;

namespace Net.Services
{
    public class DependencyRegister : IServiceStartup
    {
        public int Order => 3000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                // customer service
                .AddScoped<ICustomerService, CustomerService>()
                // product service
                .AddScoped<IProductService, ProductService>()
                // Discount service
                .AddScoped<IDiscountService, DiscountService>()
                // Order service
                .AddScoped<IOrderService, OrderService>()
                // Payment service
                .AddScoped<IPaymentService, PaymentService>()
                // shipping service
                .AddScoped<IShipmentService, ShipmentService>()
                // warehouse service
                .AddScoped<IWareHouseService, WareHouseService>();

        }
    }
}
