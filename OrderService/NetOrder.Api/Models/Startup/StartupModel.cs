
using Net.APICore.Model;
using NetOrder.Api.Models.Categories;

namespace NetOrder.Api.Models.Startup
{
    public record StartupModel : BaseModel
    {
        public IList<CategoryModel> Categories { get; set; } = new List<CategoryModel>();

        public IList<NavigatorModel> NavigatorItems { get; set; } = new List<NavigatorModel>();
    }
}
