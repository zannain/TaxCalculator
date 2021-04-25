using System;
using System.Linq;
using AngularASPNETCoreSeed.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AngularASPNETCoreSeed.Data
{
  public class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new CalculatorDBContext(
          serviceProvider.GetRequiredService<DbContextOptions<CalculatorDBContext>>()))
      {
        // Look for any board games.
        if (context.TaxBrackets.Any())
        {
          return;   // Data was already seeded
        }

        context.TaxBrackets.AddRange(
            new TaxBracket
            {
              ID = 1,
              UpperRange = 4000,
              LowerRange = 0,
              Rate = 6000

            },
            new TaxBracket
            {
              ID = 2,
              UpperRange = 86375,
              LowerRange = 40001,
              Rate = 0.12
            },
            new TaxBracket
            {
              ID = 3,
              UpperRange = 164925,
              LowerRange = 86376,
              Rate = 0.22
            },
            new TaxBracket
            {
              ID = 4,
              UpperRange = 209425,
              LowerRange = 164926,
              Rate = 0.24
            },
            new TaxBracket
            {
              ID = 5,
              UpperRange = 523600,
              LowerRange = 209426,
              Rate = 0.35
            },
            new TaxBracket
            {
              ID = 6,
              UpperRange = 999999,
              LowerRange = 523601,
              Rate = 0.37
            });

        context.SaveChanges();
      }
    }
  }
}

