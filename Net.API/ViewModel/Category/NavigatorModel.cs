namespace NetCore.ViewModel.Categories
{
    public record NavigatorModel : CategoryModel
    {
        public string Icon { get; set; } = "";

        public IList<NavigatorModel>? Childrens { get; set; }
    }
}
