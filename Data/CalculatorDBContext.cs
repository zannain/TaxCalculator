using System;
using Microsoft.EntityFrameworkCore;
using AngularASPNETCoreSeed.Models;

namespace AngularASPNETCoreSeed.Data
{
  public class CalculatorDBContext: DbContext
  {
    public CalculatorDBContext(DbContextOptions<CalculatorDBContext> options) : base(options)
    {

    }
    public DbSet<TaxBracket> TaxBrackets { get; set; }
  }
}
