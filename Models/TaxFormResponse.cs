using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_ASPNETCore_Seed.Models
{
    public class CalculatedTax
    {
        public double Tax { get; set; }
        public TaxFormulas Formula { get; set; }
        public List<CalculatedBracket> CalculatedBrackets { get; set; }
    }

    public enum TaxFormulas {
        Progressive,
        FixedRate,
        FlatTax
    }

    public class CalculatedBracket 
    {
        public TaxBracket bracket {get; set;}
        public double Amount {get; set;}
        public CalculatedBracket(TaxBracket bracket, double amount)
        {
          this.bracket = bracket;
          this.Amount = amount;
        }
    }

    public class TaxBracket
    {
        public double UpperRange { get; set; }
        public double LowerRange { get; set; }
        public double Rate { get; set; }
        public TaxBracket(double upper, double lower, double rate) 
        {
            this.UpperRange = upper;
            this.LowerRange = lower;
            this.Rate = rate;
        }
    }
}