using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngularASPNETCoreSeed.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AngularASPNETCoreSeed.Data.Repository
{
  public abstract class Repository<T> : IRepository<T> where T : class
  {
    protected readonly CalculatorDBContext _context;
    public Repository(CalculatorDBContext context)
    {
      _context = context;
    }

    public async Task<T> Get(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task Add(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
      _context.Set<T>().Update(entity);
    }


    public Task<int> Delete(int id)
    {
      throw new NotImplementedException();
    }

  }
}
