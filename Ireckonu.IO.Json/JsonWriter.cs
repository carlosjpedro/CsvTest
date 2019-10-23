using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ireckonu.Abstractions;
using Newtonsoft.Json;

namespace Ireckonu.IO.Json
{
  public class JsonWriter<T> : IWriter<T>
  {
    private readonly string _prefix;
    private readonly string _path;

    public JsonWriter(string path, string prefix)
    {
      _path = path;
      _prefix = prefix;
    }

    public async Task Write(IEnumerable<T> collection)
    {
      var json = JsonConvert.SerializeObject(collection);

      using (var writer = new StreamWriter($"{_path}/{_prefix}{DateTime.Now.Ticks}.json"))
      {
        await writer.WriteAsync(json);
      }
    }
  }
}