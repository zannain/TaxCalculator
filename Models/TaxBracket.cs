using System;
namespace AngularASPNETCoreSeed.Models
{
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
