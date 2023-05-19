using Net.APICore.Model;
using NetCore.ViewModel.Categories;

namespace NetCore.ViewModel.Product
{
    public record ProductPageModel : BaseModel
    {
        public CategoryModel Category { get; set; } = new ();

        public IList<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
