using Net.APICore.Model;
using NetOrder.Api.Models.Categories;

namespace NetCore.Models.Product
{
    public record ProductPageModel : BaseModel
    {
        public CategoryModel Category { get; set; } = new ();

        public IList<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
