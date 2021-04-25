using System;
using System.Collections.Generic;
using AngularASPNETCoreSeed.Models;

namespace AngularASPNETCoreSeed.Data.Contracts
{
  public interface ITaxBracketRepository : IRepository<TaxBracket>
  {
      new IEnumerable<TaxBracket> GetAll();
      List<TaxBracket> SortedBrackets();
      double GetFlatRate();
  }
}
