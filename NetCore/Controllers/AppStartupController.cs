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

            var childrens = new List<NavigatorItem>()
            {
                new NavigatorItem() {Id = 1, Name = "Fresh Meat", Link = "/"},
                new NavigatorItem() {Id = 2, Name = "Vegetables", Link = "/"},
                new NavigatorItem() {Id = 3, Name = "Fruit & Nut Gifts", Link = "/"},
                new NavigatorItem() {Id = 4, Name = "Fresh Berries", Link = "/"},
                new NavigatorItem() {Id = 5, Name = "Ocean Foods", Link = "/"},
                new NavigatorItem() {Id = 6, Name = "Butter & Eggs", Link = "/"},
                new NavigatorItem() {Id = 7, Name = "Fastfood", Link = "/"},
                new NavigatorItem() {Id = 8, Name = "Oatmeal", Link = "/"},
                new NavigatorItem() {Id = 9, Name = "Fresh Bananas", Link = "/"}
            };


            var NavigatorItems = new List<NavigatorItem>()
            {
                new NavigatorItem() { Id= 1, Name ="Trang chủ", Link = "/"},
                new NavigatorItem() { Id= 2, Name ="Sản phẩm", Link = "/danh-muc-san-pham", Childrens = childrens},
                new NavigatorItem() { Id= 3, Name ="Khuyến mãi", Link = "/khuyen-mai"},
                new NavigatorItem() { Id= 4, Name ="Chính sách", Link = "/chinh-sach"},
                new NavigatorItem() { Id= 5, Name ="Tin tức", Link = "/tin-tuc"},
                new NavigatorItem() { Id= 6, Name ="Liên hệ", Link = "/lien-he"}
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
