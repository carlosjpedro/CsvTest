
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ireckonu.IO.Sql
{
  public class ProductEntity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Key { get; set; }
    public string ArtikelCode { get; set; }
    public string Description { get; set; }
    public string Q1 { get; set; }
    public string Size { get; set; }
    public PriceEntity Price { get; set; }
    public ColorEntity Color { get; set; }
  }

  public class ColorEntity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string ColorDescription { get; set; }
    public string ColorCode { get; set; }
  }

  public class PriceEntity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string BasePrice { get; set; }
    public string Discount { get; set; }
  }


}
