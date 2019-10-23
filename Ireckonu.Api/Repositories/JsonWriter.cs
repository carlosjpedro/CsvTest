using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ireckonu.Api.Repositories
{
  class JsonWriter<T> : IWriter<T>
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