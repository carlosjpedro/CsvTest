
using System.ComponentModel.DataAnnotations;

namespace Ireckonu.IO.Sql
{
  public class ProductEntity
  {
    [Key]
    public string Key { get; set; }
    public string ArtikelCode { get; set; }
    public string ColorCode { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string DiscountPrice { get; set; }
    public string Q1 { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
  }
}
