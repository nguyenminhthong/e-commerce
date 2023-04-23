using Microsoft.AspNetCore.Mvc;
using Net.WebApiCore.Controller;
using NetCore.ViewModel.Categories;
using NetCore.ViewModel.Product;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]public class ProductController : ApiBaseController
    {
        [HttpGet("product-feature")]
        public async Task<IActionResult> GetProductFeature()
        {
            var products = new List<ProductModel>() {
                new ProductModel() { Id = 1, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-1.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 2, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-2.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 3, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-3.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 4, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-4.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 5, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-5.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 6, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-6.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 7, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-7.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20},
                new ProductModel() { Id = 8, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-8.jpg", OldPrice = 6500000, HasDiscountsApplied= true, Price = 350000, SalePer= 20}

            };

            await Task.Delay(500);

            return await Execute(products);
        }

        [HttpGet]
        [Route("productSales", Name = "GetProductSales")]
        public async Task<IActionResult> GetProductSales()
        {
            var products = new List<ProductModel>() {
                new ProductModel() { Id = 1, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 2, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 3, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 4, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 5, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 6, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 7, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 8, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20}
            };

            await Task.Delay(500);

            return await Execute(products);
        }

        [HttpGet]
        [Route("outstanding", Name = "GetProductOutStanding")]
        [ProducesResponseType(typeof(ProductPageModel), 200)]
        public async Task<IActionResult> GetProductOutStanding()
        {

            var Vegetables = new CategoryModel() { Id = 1, Name = "Vegetables", Link = "/" };
            var FreshMeat = new CategoryModel() { Id = 2, Name = "Fresh Meat", Link = "/" };
            var Fastfood = new CategoryModel() { Id = 3, Name = "Fastfood", Link = "/" };
            var Oatmeal = new CategoryModel() { Id = 4, Name = "Oatmeal", Link = "/" };

            var products = new List<ProductModel>() {
                new ProductModel() { Id = 1, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 2, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 3, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 4, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 5, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 6, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 7, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 8, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20}
            };

            var productPages = new List<ProductPageModel>()
            {
                new ProductPageModel() {Category =  Vegetables, Products = products},
                new ProductPageModel() {Category =  FreshMeat, Products = products},
                new ProductPageModel() {Category =  Fastfood, Products = products},
                new ProductPageModel() {Category =  Oatmeal, Products = products}

            };

            await Task.Delay(500);

            return await Execute(productPages);
        }

        [HttpGet, HttpPost]
        [Route("search", Name = "ProductSearch")]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public async Task<IActionResult> GetProducts()
        {
            var products = new List<ProductModel>() {
                new ProductModel() { Id = 1, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 2, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 3, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 4, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 5, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 6, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 7, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 8, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 9, Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 10,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 11,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 12,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 13,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-5.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 14,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-6.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 15,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-7.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 16,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-8.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 17,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-1.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 18,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-2.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 19,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-3.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20},
                new ProductModel() { Id = 20,Name="Crab Pool Security", ImagePath = "/assets/upload/featured/feature-4.jpg", Price = 6500000, HasDiscountsApplied= true, OldPrice = 350000, SalePer= 20}
            };

            await Task.Delay(1000);
            return await Execute(products);
        }
    }
}
