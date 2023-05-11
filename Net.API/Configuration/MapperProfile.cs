using AutoMapper;
using Net.Core.AutoMapper;
using Net.Domain.Products;
using NetCore.ViewModel.Product;

namespace Net.API.Configuration
{
    public class MapperProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public MapperProfile()
        {
            CreateCustomerMap();
        }

        public void CreateCustomerMap()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
