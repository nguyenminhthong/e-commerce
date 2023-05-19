using NetOrder.Api.Models.Categories;

namespace NetCore.Models.Categories
{
    public record NavigatorModel : CategoryModel
    {
        public string Icon { get; set; } = "";

        public IList<NavigatorModel>? Childrens { get; set; }
    }
}
