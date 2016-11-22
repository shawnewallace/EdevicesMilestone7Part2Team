using EDeviceClaims.Core;

namespace EDeviceClaims.Repositories
{
  public interface IEfRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
  {
    IEfUnitOfWork EfUnitOfWork { get; set; }
  }
}