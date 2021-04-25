using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_ASPNETCore_Seed.Models
{
    public static class Tax {
        public static List<TaxBracket> SeedData()
        {
            List<TaxBracket> brackets = new List<TaxBracket>()
            {
                new TaxBracket(40000, 0, 6000),
                new TaxBracket(86375, 40001,  12),
                new TaxBracket(164925, 86376, 22),
                new TaxBracket(209425, 164926, 24),
                new TaxBracket(523600, 209426, 35),
                new TaxBracket(999999, 523601, 37),
            };
      return brackets;
        }
    public static int FlatTax()
    {
      return 6000;
    }

    public static TaxFormResponse CalculateProgressiveTax(int income, List<TaxBracket> brackets)
    {
      TaxFormResponse response = new TaxFormResponse();
      response.CalculatedBrackets = new List<CalculatedBracket>();
      response.Formula = TaxFormulas.Progressive;
      List<TaxBracket> bracketsToCalculate = new List<TaxBracket>();
      foreach (TaxBracket bracket in brackets)
      {
        if (income > bracket.LowerRange)
        {
          bracketsToCalculate.Add(bracket);
        }
      }
      foreach (TaxBracket bracket in bracketsToCalculate)
      {
        if (bracket.LowerRange == 0)
        {
          CalculatedBracket calculated = new CalculatedBracket(bracket, bracket.Rate);
          response.CalculatedBrackets.Add(calculated);
          response.Tax += bracket.Rate;
          continue;
        }
        if (bracket.LowerRange < income && bracket.UpperRange < income)
        {
          var taxableIncome = bracket.UpperRange - bracket.LowerRange;
          var bracketTax = taxableIncome * (bracket.Rate / 100);
          CalculatedBracket calculated = new CalculatedBracket(bracket, bracketTax);
          response.CalculatedBrackets.Add(calculated);
          response.Tax += bracketTax;
          continue;
        }
        if (bracket.UpperRange > income)
        {
          var taxableIncome = income - bracket.LowerRange;
          var bracketTax = taxableIncome * (bracket.Rate/100);
          CalculatedBracket calculated = new CalculatedBracket(bracket,bracketTax);
          response.CalculatedBrackets.Add(calculated);
          response.Tax += bracketTax;
          continue;
        }


      }
      return response;
    }
    }
}
