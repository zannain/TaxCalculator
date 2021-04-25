using System;
namespace AngularASPNETCoreSeed.Models
{
  public class TaxBracket
  {
    public int ID { get; set; }
    public double LowerRange { get; set; }
    public double Rate { get; set; }
    public double UpperRange { get; set; }
  }
}
