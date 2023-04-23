using Net.WebApiCore.Model;

namespace NetCore.ViewModel.Categories
{
    public record CategoryModel : BaseModel
    {
        public int Id { get; set; }

        public string Link { get; set; } = "";

        public string Name { get; set; } = "";

        public string ImageUrl { get; set; } = "";
    }
}
