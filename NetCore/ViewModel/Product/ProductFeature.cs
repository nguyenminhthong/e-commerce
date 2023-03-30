namespace NetCore.ViewModel.Product
{
    public record ProductFeature
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal Price { get; set; }

        public bool HasSale { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? SalePer { get; set; }
    }
}
