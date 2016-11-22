using System;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using EDeviceClaims.Repositories.Contexts;

namespace EDeviceClaims.Repositories
{
  public class EfUnitOfWork : IEfUnitOfWork
  {

    public DbContext Context
    {
      get { return _context ?? (_context = new EDeviceClaimsContext()); }
      set { _context = value; }
    }
    private DbContext _context;


    public EfUnitOfWork() { }
    public EfUnitOfWork(DbContext context) { Context = context; }
    public void Commit() { Context.SaveChanges(); }
    public void Dispose() { Context.Dispose(); }

    public bool LazyLoadingEnabled
    {
      get { return Context.Configuration.LazyLoadingEnabled; }
      set { Context.Configuration.LazyLoadingEnabled = value; }
    }
  }
}
