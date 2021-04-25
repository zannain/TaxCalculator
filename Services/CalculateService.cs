using System.Collections.Generic;
using System.Linq;
using Angular_ASPNETCore_Seed.Models;
using AngularASPNETCoreSeed.Data.Contracts;
using AngularASPNETCoreSeed.Interfaces;
using AngularASPNETCoreSeed.Models;

namespace AngularASPNETCoreSeed.Services
{
  public class CalculateService : ITaxBracketService
  {
    private ITaxBracketRepository _taxBracketRepository;
    public CalculateService(ITaxBracketRepository taxBracketRepository)
    {
      _taxBracketRepository = taxBracketRepository;
    }
    public CalculatedTax CalculateAllBrackets(TaxForm body)
    {
      var income = body.Income;

      List<TaxBracket> brackets = _taxBracketRepository.SortedBrackets();
      TaxBracket firstNonZeroBracket =  brackets.Where(x => x.LowerRange != 0).FirstOrDefault();
      if (body.Frequency == "Monthly") income = CalculateAnnualIncome(body.Income);
      if (body.State == "CA" || body.State == "VA" || body.State == "NY")
      {
        if (income > firstNonZeroBracket.LowerRange || income == firstNonZeroBracket.LowerRange)
        {
          CalculatedTax response = CalculateProgressiveTax(income, brackets);
          return response;
        }
        else
        {
          CalculatedTax response = new CalculatedTax();
          response.Formula = TaxFormulas.FixedRate;
          var fixedRate = brackets.First();
          response.Tax = fixedRate.Rate;
          return response;
        }
      }
      else
      {
        CalculatedTax response = new CalculatedTax();
        response.Formula = TaxFormulas.FlatTax;
        response.Tax = _taxBracketRepository.GetFlatRate();
        return response;
      }
    }
    public double CalculateAnnualIncome(double income)
    {
      return income * 12;
    }
    public CalculatedTax CalculateProgressiveTax(double income, List<TaxBracket> brackets)
    {
      CalculatedTax response = new CalculatedTax();
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
          var bracketTax = taxableIncome * bracket.Rate;
          CalculatedBracket calculated = new CalculatedBracket(bracket, bracketTax);
          response.CalculatedBrackets.Add(calculated);
          response.Tax += bracketTax;
          continue;
        }
        if (bracket.UpperRange > income)
        {
          var taxableIncome = income - bracket.LowerRange;
          var bracketTax = taxableIncome * bracket.Rate;
          bracket.UpperRange = income;
          CalculatedBracket calculated = new CalculatedBracket(bracket, bracketTax);
          response.CalculatedBrackets.Add(calculated);
          response.Tax += bracketTax;
          continue;
        }


      }
      return response;
    }
  }
}
