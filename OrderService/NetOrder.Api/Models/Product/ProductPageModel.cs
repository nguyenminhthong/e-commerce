using Net.APICore.Model;
using NetOrder.Api.Models.Categories;

namespace NetOrder.Api.Models.Product
{
    public record ProductPageModel : BaseModel
    {
        public CategoryModel Category { get; set; } = new ();

        public IList<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
