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

            return new RawJsonResult<IEnumerable<ProductModel>>(products);
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

            return new RawJsonResult<IEnumerable<ProductModel>>(products);
        }

        [HttpGet]
        [Route("products", Name = "GetProducts")]
        [ProducesResponseType(typeof(ProductModel), 200)]
        public async Task<IActionResult> Index()
        {

            var Vegetables = new CategoryModel() { Id = 1, Title = "Vegetables", Link = "/" };
            var FreshMeat = new CategoryModel() { Id = 2, Title = "Fresh Meat", Link = "/" };
            var Fastfood = new CategoryModel() { Id = 3, Title = "Fastfood", Link = "/" };
            var Oatmeal = new CategoryModel() { Id = 4, Title = "Oatmeal", Link = "/" };

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

            return new RawJsonResult<IEnumerable<ProductPageModel>>(productPages);
        }

    }
}
