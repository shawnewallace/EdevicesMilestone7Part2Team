using System;

namespace EDeviceClaims.Core
{
  public interface IUnitOfWork : IDisposable
  {
    void Commit();
    bool LazyLoadingEnabled { get; set; }
  }
}