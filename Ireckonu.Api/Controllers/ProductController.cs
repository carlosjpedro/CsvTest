using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CsvHelper;
using Ireckonu.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ireckonu.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Consumes("text/csv", "multipart/form-data")]
  public class ProductController : ControllerBase
  {
    [HttpPost]

    public async Task<IActionResult> PostAsync()
    {
      using (StreamReader reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
      {
        using (var csvReader = new CsvReader(reader))
        {
          var productCollection = new List<Product>();
          while (await csvReader.ReadAsync())
          {
            var product = csvReader.GetRecord<Product>();
            productCollection.Add(product);
          }

          var json = JsonConvert.SerializeObject(productCollection);

          return Ok(json);
        }
      }
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok();
    }
  }
}
