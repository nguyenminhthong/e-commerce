
using Net.APICore.Model;
using NetCore.Models.Product;
using NetOrder.Api.Models.Campaign;
using NetOrder.Api.Models.Categories;

namespace NetCore.Models.HomePage
{
    public record HomePageModel : BaseModel
    {
        public IList<CampaignModel> campaigns { get; set; } = new List<CampaignModel>();

        public IList<CategoryModel> categories { get; set; } = new List<CategoryModel>();

        public IList<ProductModel> products { get; set; } = new List<ProductModel>();
    }
}
