﻿using Net.WebApiCore.Model;
using NetCore.ViewModel.Categories;

namespace NetCore.ViewModel.Product
{
    public record ProductPageModel : BaseModel
    {
        public CategoryModel Category { get; set; }

        public IList<ProductModel> Products { get; set; }
    }
}
