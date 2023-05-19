
using Net.APICore.Model;
using NetOrder.Api.Models.Product;
using NetOrder.Api.Models.Campaign;
using NetOrder.Api.Models.Categories;

namespace NetOrder.Api.Models.HomePage
{
    public record HomePageModel : BaseModel
    {
        public IList<CampaignModel> campaigns { get; set; } = new List<CampaignModel>();

        public IList<CategoryModel> categories { get; set; } = new List<CategoryModel>();

        public IList<ProductModel> products { get; set; } = new List<ProductModel>();
    }
}
