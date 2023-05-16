using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.APICore.Authorization.Attributes;
using Net.APICore.Controller;
using NetCore.ViewModel.Categories;
using NetCore.ViewModel.Startup;

namespace NetCore.Controllers
{
    [ApiController]
    [Authorize(Policy = JwtBearerDefaults.AuthenticationScheme)]
    public class AppStartupController : ApiBaseController
    {
        [HttpGet]
        [Route("api/startup", Name = "startup")]
        [AuthorizePermission("Public")]
        public async Task<IActionResult> GetStartupData()
        {
            var Categories = new List<CategoryModel>()
            {
                new CategoryModel() {Id = 1, Name = "Fresh Meat", Link = "/"},
                new CategoryModel() {Id = 2, Name = "Vegetables", Link = "/"},
                new CategoryModel() {Id = 3, Name = "Fruit & Nut Gifts", Link = "/"},
                new CategoryModel() {Id = 4, Name = "Fresh Berries", Link = "/"},
                new CategoryModel() {Id = 5, Name = "Ocean Foods", Link = "/"},
                new CategoryModel() {Id = 6, Name = "Butter & Eggs", Link = "/"},
                new CategoryModel() {Id = 7, Name = "Fastfood", Link = "/"},
                new CategoryModel() {Id = 8, Name = "Oatmeal", Link = "/"},
                new CategoryModel() {Id = 9, Name = "Fresh Bananas", Link = "/"}
            };

            var childrens = new List<NavigatorModel>()
            {
                new NavigatorModel() {Id = 1, Name = "Fresh Meat", Link = "/"},
                new NavigatorModel() {Id = 2, Name = "Vegetables", Link = "/"},
                new NavigatorModel() {Id = 3, Name = "Fruit & Nut Gifts", Link = "/"},
                new NavigatorModel() {Id = 4, Name = "Fresh Berries", Link = "/"},
                new NavigatorModel() {Id = 5, Name = "Ocean Foods", Link = "/"},
                new NavigatorModel() {Id = 6, Name = "Butter & Eggs", Link = "/"},
                new NavigatorModel() {Id = 7, Name = "Fastfood", Link = "/"},
                new NavigatorModel() {Id = 8, Name = "Oatmeal", Link = "/"},
                new NavigatorModel() {Id = 9, Name = "Fresh Bananas", Link = "/"}
            };


            var NavigatorItems = new List<NavigatorModel>()
            {
                new NavigatorModel() { Id= 1, Name ="Trang chủ", Link = "/"},
                new NavigatorModel() { Id= 2, Name ="Sản phẩm", Link = "/danh-muc-san-pham", Childrens = childrens},
                new NavigatorModel() { Id= 3, Name ="Khuyến mãi", Link = "/khuyen-mai"},
                new NavigatorModel() { Id= 4, Name ="Chính sách", Link = "/chinh-sach"},
                new NavigatorModel() { Id= 5, Name ="Tin tức", Link = "/tin-tuc"},
                new NavigatorModel() { Id= 6, Name ="Liên hệ", Link = "/lien-he"}
            };

            var model = new StartupModel()
            {
                Categories = Categories,
                NavigatorItems = NavigatorItems
            };

            await Task.Delay(500);

            return await Json(model);
        }
    }
}
