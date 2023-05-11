using Net.APICore.Model;

namespace NetCore.ViewModel.Product
{
    public record ProductModel : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string ImagePath { get; set; } = "";

        public decimal Price { get; set; }

        public bool MaskAsNew { get; set; }

        public bool HasDiscountsApplied { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SalePer { get; set; }
    }
}
