using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularASPNETCoreSeed.Data.Contracts
{
  public interface IRepository<T> where T : class
  {
    Task<IEnumerable<T>> GetAll();
  }
}
