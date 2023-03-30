using NetCore.ViewModel.Categories;

namespace NetCore.ViewModel.Startup
{
    public record StartupModel
    {
        public IList<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        public IList<NavigatorItem> NavigatorItems { get; set; } = new List<NavigatorItem>();
    }
}
