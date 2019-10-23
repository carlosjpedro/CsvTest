using System.Collections.Generic;
using Ireckonu.Models;

namespace Ireckonu.IO.Sql.Mappers
{
  public interface IProductMapper
  {
    IEnumerable<ProductEntity> Map(IEnumerable<Product> productCollection);
  }
}