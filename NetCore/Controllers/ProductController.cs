using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.JsonResult;
using NetCore.ViewModel.Categories;
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

            await Task.Delay(500);

            return new RawJsonResult<IEnumerable<ProductFeature>>(products);
        }

        [HttpGet]
        [Route("productSales", Name = "GetProductSales")]
        public async Task<IActionResult> GetProductSales()
        {
            var products = new List<Product>() {
                new Product() { ProductId = 1, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 2, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 3, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 4, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 5, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 6, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 7, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 8, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20}
            };

            await Task.Delay(500);

            return new RawJsonResult<IEnumerable<Product>>(products);
        }

        [HttpGet]
        [Route("products", Name = "GetProducts")]
        public async Task<IActionResult> Index()
        {

            var Vegetables = new CategoryModel() { Id = 1, Title = "Vegetables", Link = "/" };
            var FreshMeat = new CategoryModel() { Id = 2, Title = "Fresh Meat", Link = "/" };
            var Fastfood = new CategoryModel() { Id = 3, Title = "Fastfood", Link = "/" };
            var Oatmeal = new CategoryModel() { Id = 4, Title = "Oatmeal", Link = "/" };

            var products = new List<Product>() {
                new Product() { ProductId = 1, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 2, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 3, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 4, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 5, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 6, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 7, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20},
                new Product() { ProductId = 8, ProductName="Crab Pool Security", ProductImage = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasSale= true, SalePrice = 350000, SalePer= 20}
            };

            var productPages = new List<ProductPage>()
            {
                new ProductPage() {Category =  Vegetables, Products = products},
                new ProductPage() {Category =  FreshMeat, Products = products},
                new ProductPage() {Category =  Fastfood, Products = products},
                new ProductPage() {Category =  Oatmeal, Products = products}

            };

            await Task.Delay(500);

            return new RawJsonResult<IEnumerable<ProductPage>>(productPages);
        }

    }
}
