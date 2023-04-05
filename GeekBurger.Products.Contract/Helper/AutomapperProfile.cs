using AutoMapper;
using GeekBurger.Products.Contract;
using GeekBurger.StoreCatalog.Contract;


namespace GeekBurger.Products.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductToUpsert, Product>();
            CreateMap<Product, ProductToUpsert>();
            CreateMap<Product, ProductToGet>();
        }
    }
}
