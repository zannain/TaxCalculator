using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_ASPNETCore_Seed.Models
{
    public class TaxFormRequest
    {
        public int Income { get; set; }
        public string State { get; set; }
        public string Frequency { get; set; }
    }
}