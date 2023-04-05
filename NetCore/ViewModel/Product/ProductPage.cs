using NetCore.ViewModel.Categories;

namespace NetCore.ViewModel.Product
{
    public record ProductPage
    {
        public CategoryModel Category { get; set; }

        public IList<Product> Products { get; set; }
    }
}
