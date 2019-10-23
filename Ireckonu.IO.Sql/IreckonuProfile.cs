using AutoMapper;
using Ireckonu.Models;

namespace Ireckonu.IO.Sql
{
  public class IreckonuProfile : Profile
  {
    public IreckonuProfile()
    {
      CreateMap<Product, ProductEntity>();
    }
  }
}