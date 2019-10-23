using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ireckonu.Abstractions;
using Newtonsoft.Json;

namespace Ireckonu.IO.Json
{
  public class JsonWriter<T> : IWriter<T>
  {
    public async Task Write(IEnumerable<T> entityCollection)
    {
      var json = JsonConvert.SerializeObject(entityCollection);

      using (var writer = new StreamWriter("file.json"))
      {
        await writer.WriteAsync(json);
      }
    }
  }
}