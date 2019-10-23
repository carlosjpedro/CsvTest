using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ireckonu.Api.Repositories
{
  public interface IWriter<T>
  {
    Task Write(IEnumerable<T> entityCollection);
  }
}
