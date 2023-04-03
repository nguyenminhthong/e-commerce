using Microsoft.AspNetCore.Mvc;
using NetCore.JsonResult;
using NetCore.ViewModel.Categories;
using NetCore.ViewModel.Startup;

namespace NetCore.Controllers
{
    [ApiController]
    public class AppStartupController : ControllerBase
    {
        [HttpGet]
        [Route("api/startup", Name = "startup")]
        public async Task<IActionResult> GetStartupData()
        {
            var Categories = new List<CategoryModel>()
            {
                new CategoryModel() {Id = 1, Title = "Fresh Meat", Link = "/"},
                new CategoryModel() {Id = 2, Title = "Vegetables", Link = "/"},
                new CategoryModel() {Id = 3, Title = "Fruit & Nut Gifts", Link = "/"},
                new CategoryModel() {Id = 4, Title = "Fresh Berries", Link = "/"},
                new CategoryModel() {Id = 5, Title = "Ocean Foods", Link = "/"},
                new CategoryModel() {Id = 6, Title = "Butter & Eggs", Link = "/"},
                new CategoryModel() {Id = 7, Title = "Fastfood", Link = "/"},
                new CategoryModel() {Id = 8, Title = "Oatmeal", Link = "/"},
                new CategoryModel() {Id = 9, Title = "Fresh Bananas", Link = "/"}
            };

            var childrens = new List<NavigatorItem>()
            {
                new NavigatorItem() {Id = 1, Title = "Fresh Meat", Link = "/"},
                new NavigatorItem() {Id = 2, Title = "Vegetables", Link = "/"},
                new NavigatorItem() {Id = 3, Title = "Fruit & Nut Gifts", Link = "/"},
                new NavigatorItem() {Id = 4, Title = "Fresh Berries", Link = "/"},
                new NavigatorItem() {Id = 5, Title = "Ocean Foods", Link = "/"},
                new NavigatorItem() {Id = 6, Title = "Butter & Eggs", Link = "/"},
                new NavigatorItem() {Id = 7, Title = "Fastfood", Link = "/"},
                new NavigatorItem() {Id = 8, Title = "Oatmeal", Link = "/"},
                new NavigatorItem() {Id = 9, Title = "Fresh Bananas", Link = "/"}
            };


            var NavigatorItems = new List<NavigatorItem>()
            {
                new NavigatorItem() { Id= 1, Title ="Trang chủ", Link = "/"},
                new NavigatorItem() { Id= 2, Title ="Sản phẩm", Link = "/san-pham", Childrens = childrens},
                new NavigatorItem() { Id= 3, Title ="Khuyến mãi", Link = "/khuyen-mai"},
                new NavigatorItem() { Id= 4, Title ="Chính sách", Link = "/chinh-sach"},
                new NavigatorItem() { Id= 5, Title ="Tin tức", Link = "/tin-tuc"},
                new NavigatorItem() { Id= 6, Title ="Liên hệ", Link = "/lien-he"}
            };

            var model = new StartupModel()
            {
                Categories = Categories,
                NavigatorItems = NavigatorItems
            };

            await Task.Delay(500);

            return RawJsonResult<StartupModel>.Send(model);
        }
    }
}
