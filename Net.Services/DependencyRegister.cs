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
            // customer service
            services.AddScoped<ICustomerService, CustomerService>();

            // product service
            services.AddScoped<IProductService, ProductService>();

            // Discount service
            services.AddScoped<IDiscountService, DiscountService>();

            // Order service
            services.AddScoped<IOrderService, OrderService>();

            // Payment service
            services.AddScoped<IPaymentService, PaymentService>();

            // shipping service
            services.AddScoped<IShipmentService, ShipmentService>();

            // warehouse service
            services.AddScoped<IWareHouseService, WareHouseService>();

        }
    }
}
