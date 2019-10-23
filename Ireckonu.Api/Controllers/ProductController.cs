using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CsvHelper;
using Ireckonu.Api.Parsers;
using Ireckonu.Api.Repositories;
using Ireckonu.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ireckonu.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Consumes("text/csv")]
  public class ProductController : ControllerBase
  {
    private readonly ICsvStreamParser<Product> _streamParser;
    private readonly IEnumerable<IWriter<Product>> _writers;

    public ProductController(ICsvStreamParser<Product> streamParser, IEnumerable<IWriter<Product>> writers)
    {
      _streamParser = streamParser;
      _writers = writers;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync()
    {
      var productCollection = await _streamParser.ParseAsync(HttpContext.Request.Body);

      foreach (var writer in _writers)
      {
        await writer.Write(productCollection);
      }

      return Ok();
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok();
    }
  }
}
