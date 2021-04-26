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
using AngularASPNETCoreSeed.Data;
using AngularASPNETCoreSeed.Data.Repository;
using AngularASPNETCoreSeed.Data.Contracts;
using AngularASPNETCoreSeed.Services;
using AngularASPNETCoreSeed.Interfaces;

namespace Angular_ASPNETCore_Seed.Apis
{
  [Route("api/[controller]")]
  [ApiController]
    public class TaxController : Controller
    {

      private ITaxBracketService _calculator;

      public TaxController(ITaxBracketService calculator)
      {
        _calculator = calculator;
      }

      [HttpPost]
      public async Task<IActionResult> GetTax([FromBody]TaxForm body)
      {
          CalculatedTax response = _calculator.CalculateAllBrackets(body);
          return Ok(response);
      }
    }
}