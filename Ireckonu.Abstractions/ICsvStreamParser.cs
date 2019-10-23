using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ireckonu.Abstractions
{
  public interface ICsvStreamParser<T>
  {
    Task<IEnumerable<T>> ParseAsync(Stream stream);
  }
}


