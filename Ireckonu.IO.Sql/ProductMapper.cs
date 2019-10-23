using System.Collections.Generic;
using AutoMapper;
using Ireckonu.Models;

namespace Ireckonu.IO.Sql
{
  public class ProductMapper : IProductMapper
  {
    private readonly IMapper _mapper;

    public ProductMapper(IMapper mapper)
    {
      _mapper = mapper;
    }
    public IEnumerable<ProductEntity> Map(IEnumerable<Product> productCollection)
    {
      return _mapper.Map<IEnumerable<ProductEntity>>(productCollection);
    }
  }
}