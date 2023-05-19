using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using Net.Core.Services;
using NetOrder.Services.Discount;
using NetOrder.Services.Order;
using NetOrder.Services.Payments;
using NetOrder.Services.Product;
using NetOrder.Services.Shipping;
using NetOrder.Services.WareHouse;

namespace NetOrder.Services
{
    public class ServiceStartup : IServiceStartup
    {
        public int Order => 3000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
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
