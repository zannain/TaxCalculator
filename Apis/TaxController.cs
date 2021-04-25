using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Angular_ASPNETCore_Seed.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using AngularASPNETCoreSeed.Models;

namespace Angular_ASPNETCore_Seed.Apis
{
  [Route("api/[controller]")]
  [ApiController]
  public class TaxController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> GetTax([FromBody]TaxForm body)
        {
            List<TaxBracket> brackets = Tax.SeedData();
            List<TaxBracket> sortedBrackets = (from bracket in brackets
                                        orderby bracket.LowerRange
                                        select bracket).ToList();
              List<double> excludeFixedRateBracket = (from bracket in sortedBrackets
                                          where bracket.LowerRange != 0
                                          select bracket.LowerRange).ToList();
            if (body.State == "CA" || body.State == "VA" || body.State == "NY")
            {
              if (body.Income > excludeFixedRateBracket.First())
              {
                CalculatedTax response = Tax.CalculateProgressiveTax(body.Income, sortedBrackets);
                return Ok(response);
              }
              else
              {
                CalculatedTax response = new CalculatedTax();
                response.Formula = TaxFormulas.FixedRate;
                var fixedRate = sortedBrackets.First();
                response.Tax = fixedRate.Rate;
                return Ok(response);
              }
            }
            else
            {
              CalculatedTax response = new CalculatedTax();
              response.Formula = TaxFormulas.FlatTax;
              response.Tax = Tax.FlatTax();
              return Ok(response);
            }
        }
    }
}