using System.Data.Entity;
using EDeviceClaims.Repositories.Contexts;

namespace EDeviceClaims.Repositories
{
  public class EDeviceClaimsUnitOfWork : EfUnitOfWork
  {
    public EDeviceClaimsUnitOfWork()
    {
      Context = new EDeviceClaimsContext();
    }

    public EDeviceClaimsUnitOfWork(DbContext context)
    {
      Context = context;
    }
  }
}