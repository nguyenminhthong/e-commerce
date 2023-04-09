namespace NetCore.ViewModel.Categories
{
    public record NavigatorItem : CategoryModel
    {
        public string Icon { get; set; } = "";

        public IList<NavigatorItem>? Childrens { get; set; }
    }
}
