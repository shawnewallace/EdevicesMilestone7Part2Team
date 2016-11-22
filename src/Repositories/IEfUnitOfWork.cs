using System.Data.Entity;
using EDeviceClaims.Core;

namespace EDeviceClaims.Repositories
{
  public interface IEfUnitOfWork : IUnitOfWork
  {
    DbContext Context { get; set; }
  }
}