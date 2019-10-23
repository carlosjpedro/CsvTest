using System;
using Microsoft.EntityFrameworkCore;

namespace Ireckonu.IO.Sql
{
  public class IreckonuContext : DbContext
  {
    public IreckonuContext(DbContextOptions<IreckonuContext> options) : base(options)
    {

    }

    public DbSet<ProductEntity> Products { get; set; }
  }
}
