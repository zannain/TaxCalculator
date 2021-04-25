using System;
namespace AngularASPNETCoreSeed.Models
{
  public class CalculatedBracket
  {
    public CalculatedBracket()
    {
    }
    public CalculatedBracket(TaxBracket bracket, double amount)
    {
      this.bracket = bracket;
      this.Amount = amount;
    }
    public TaxBracket bracket { get; set; }
    public double Amount { get; set; }
  }
}
