namespace NetCore.ViewModel.Categories
{
    public record CategoryModel
    {
        public int Id { get; set; }

        public string Link { get; set; } = "";

        public string Title { get; set; } = "";

        public bool HasChildren { get; set; }

        public IList<CategoryModel>? Childrens { get; set; }
    }
}
