using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularASPNETCoreSeed.Models;

namespace Angular_ASPNETCore_Seed.Models
{
    public class CalculatedTax
    {
        public double Tax { get; set; }
        public TaxFormulas Formula { get; set; }
        public List<CalculatedBracket> CalculatedBrackets { get; set; }
    }



  
}