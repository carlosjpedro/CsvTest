using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Ireckonu.Api.Dto;

namespace Ireckonu.Api.Parsers
{
  class ProductCsvStreamParser : ICsvStreamParser<Product>
  {
    public async Task<IEnumerable<Product>> ParseAsync(Stream stream)
    {
      var productCollection = new List<Product>();
      using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
      {
        using (var csvReader = new CsvReader(reader))
        {
          while (await csvReader.ReadAsync())
          {
            productCollection.Add(csvReader.GetRecord<Product>());
          }
          return productCollection;
        }
      }
    }
  }
}