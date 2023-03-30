using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.JsonResult;
using NetCore.ViewModel.Product;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("product-feature")]
        public async Task<IActionResult> GetProductFeature()
        {
            var products = new List<ProductFeature>() { 
                new ProductFeature() { ProductId = 1, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 2, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 3, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 4, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 5, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 6, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 7, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new ProductFeature() { ProductId = 8, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20}
            
            };

            return new RawJsonResult<IEnumerable<ProductFeature>>(products);
        }

        [HttpGet]
        [Route("api/products", Name ="GetProducts")]
        public async Task<IActionResult> Index()
        {
            var products = new List<Product>();

            return new RawJsonResult<IEnumerable<Product>>(products);
        }
    }
}
