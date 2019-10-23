using System.Collections.Generic;
using System.Linq;
using Ireckonu.Models;

namespace Ireckonu.IO.Sql.Mappers
{
  public class ProductMapper : IProductMapper
  {
    public IEnumerable<ProductEntity> Map(IEnumerable<Product> productCollection)
    {
      return productCollection.Select(Map);
    }

    private ProductEntity Map(Product product)
    {
      return new ProductEntity
      {
        ArtikelCode = product.ArtikelCode,
        Description = product.Description,
        Key = product.Key,
        Q1 = product.Q1,
        Price = new PriceEntity
        {
          BasePrice = product.Price,
          Discount = product.DiscountPrice
        },
        Size = product.Size,
        Color = new ColorEntity
        {
          ColorCode = product.ColorCode,
          ColorDescription = product.Color
        }
      };
    }
  }
}