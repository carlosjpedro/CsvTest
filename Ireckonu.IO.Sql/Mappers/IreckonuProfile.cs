using AutoMapper;
using Ireckonu.Models;

namespace Ireckonu.IO.Sql.Mappers
{
  public class IreckonuProfile : Profile
  {
    public IreckonuProfile()
    {
      CreateMap<Product, PriceEntity>()
        .ForMember(x => x.BasePrice, opt => opt.MapFrom(x => x.Price))
        .ForMember(x => x.Discount, opt => opt.MapFrom(x => x.DiscountPrice));
      CreateMap<Product, ColorEntity>()
        .ForMember(x => x.ColorCode, opt => opt.MapFrom(x => x.ColorCode))
        .ForMember(x => x.ColorDescription, opt => opt.MapFrom(x => x.Color));
      CreateMap<Product, ProductEntity>();

    }
  }
}