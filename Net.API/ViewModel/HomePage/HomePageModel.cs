using Net.APICore.Model;
using NetCore.ViewModel.Campaign;
using NetCore.ViewModel.Categories;
using NetCore.ViewModel.Product;

namespace NetCore.ViewModel.HomePage
{
    public record HomePageModel : BaseModel
    {
        public IList<CampaignModel> campaigns { get; set; } = new List<CampaignModel>();

        public IList<CategoryModel> categories { get; set; } = new List<CategoryModel>();

        public IList<ProductModel> products { get; set; } = new List<ProductModel>();
    }
}
