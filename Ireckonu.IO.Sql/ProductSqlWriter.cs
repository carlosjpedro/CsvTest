using System.Collections.Generic;
using System.Threading.Tasks;
using Ireckonu.Abstractions;
using Ireckonu.Models;

namespace Ireckonu.IO.Sql
{
  public class ProductSqlWriter : IWriter<Product>
  {
    private readonly IreckonuContext _context;
    private readonly IProductMapper _mapper;

    public ProductSqlWriter(IreckonuContext context, IProductMapper mapper)
    {
      context.Database.EnsureCreated();
      _context = context;
      _mapper = mapper;
    }
    public async Task Write(IEnumerable<Product> collection)
    {
      var entities = _mapper.Map(collection);
      await _context.Products.AddRangeAsync(entities);
      await _context.SaveChangesAsync();
    }
  }
}