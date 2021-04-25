using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularASPNETCoreSeed.Data.Contracts;
using AngularASPNETCoreSeed.Models;

namespace AngularASPNETCoreSeed.Data.Repository
{
  public class TaxBracketRepository : ITaxBracketRepository
  {
    private readonly CalculatorDBContext _context;
    public TaxBracketRepository(CalculatorDBContext context)
    {
      _context = context;
    }

    public List<TaxBracket> SortedBrackets()
    {
      var allBrackets = GetAll();
      return (from bracket in allBrackets
              orderby bracket.LowerRange
              select bracket).ToList();

    }
    public IEnumerable<TaxBracket> GetAll()
    {
      return _context.TaxBrackets.ToList();
    }
    public double GetFlatRate()
    {
      TaxBracket flatRateBracket = _context.TaxBrackets.Where(bracket => bracket.LowerRange == 0).FirstOrDefault();
      if (flatRateBracket != null)
      {
        return flatRateBracket.Rate;
      }
      else
      {
        return 0;
      }      
    }
    Task<IEnumerable<TaxBracket>> IRepository<TaxBracket>.GetAll()
    {
      throw new NotImplementedException();
    }
  }
}
