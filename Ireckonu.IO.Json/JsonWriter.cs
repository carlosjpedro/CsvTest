using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ireckonu.Abstractions;
using Newtonsoft.Json;

namespace Ireckonu.IO.Json
{
  public class JsonWriter<T> : IWriter<T>
  {
    public async Task Write(IEnumerable<T> collection)
    {
      var json = JsonConvert.SerializeObject(collection);

      using (var writer = new StreamWriter("file.json"))
      {
        await writer.WriteAsync(json);
      }
    }
  }
}