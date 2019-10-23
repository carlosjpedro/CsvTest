using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ireckonu.Abstractions
{
  public interface IWriter<T>
  {
    Task Write(IEnumerable<T> collection);
  }
}
