using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ireckonu.Api.Parsers
{
  public interface ICsvStreamParser<T>
  {
    Task<IEnumerable<T>> ParseAsync(Stream stream);
  }
}


