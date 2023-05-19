using Microsoft.AspNetCore.Mvc;
using NetOrder.ApiCore.Controller;
using NetCore.ViewModel.Categories;
using NetCore.ViewModel.HomePage;
using NetCore.ViewModel.Product;

namespace NetCore.Controllers
{
    public class HomePageController : ApiBaseController
    {
        [HttpGet]
        [Route("common")]
        [ProducesResponseType(typeof(HomePageModel), 200)]
        public async Task<IActionResult> Index()
        {
            var response = new HomePageModel();

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

            var categories = new List<CategoryModel>()
            {
                new CategoryModel() {Id = 1, Name = "Fresh Meat", Link = "/", ImageUrl ="cat-1.jpg"},
                new CategoryModel() {Id = 2, Name = "Vegetables", Link = "/", ImageUrl ="cat-2.jpg"},
                new CategoryModel() {Id = 3, Name = "Fruit & Nut Gifts", Link = "/", ImageUrl ="cat-3.jpg"},
                new CategoryModel() {Id = 4, Name = "Fresh Berries", Link = "/", ImageUrl = "cat-4.jpg"},
                new CategoryModel() {Id = 5, Name = "Ocean Foods", Link = "/", ImageUrl = "cat-5.jpg"},
                new CategoryModel() {Id = 6, Name = "Butter & Eggs", Link = "/", ImageUrl = "cat-1.jpg"},
                new CategoryModel() {Id = 7, Name = "Fastfood", Link = "/", ImageUrl = "cat-2.jpg"},
                new CategoryModel() {Id = 8, Name = "Oatmeal", Link = "/", ImageUrl = "cat-3.jpg"},
                new CategoryModel() {Id = 9, Name = "Fresh Bananas", Link = "/", ImageUrl = "cat-4.jpg"}
            };

            response.products = products;
            response.categories = categories;


            await Task.Delay(100);

            return await Json(response);
        }
    }
}
