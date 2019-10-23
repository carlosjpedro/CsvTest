using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        var text = await reader.ReadToEndAsync();
        return Ok(text);
      }
    }

    [HttpGet]
    public IActionResult Get()
    { 
      return Ok();
    }
  }
}
