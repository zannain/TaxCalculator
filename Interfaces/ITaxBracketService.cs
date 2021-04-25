using System.Collections.Generic;
using Angular_ASPNETCore_Seed.Models;
using AngularASPNETCoreSeed.Models;

namespace AngularASPNETCoreSeed.Interfaces
{
  public interface ITaxBracketService
  {
    CalculatedTax CalculateAllBrackets(TaxForm form);
    CalculatedTax CalculateProgressiveTax(double income, List<TaxBracket> brackets);
    double CalculateAnnualIncome(double monthlyIncome);
  }
}
