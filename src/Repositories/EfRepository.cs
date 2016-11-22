using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EDeviceClaims.Core;

namespace EDeviceClaims.Repositories
{
  public class EfRepository<TEntity, TKey> : IEfRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
  {
    public IUnitOfWork UnitOfWork { get; set; }

    public IEfUnitOfWork EfUnitOfWork { get; set; }

    public EfRepository() { }
    public EfRepository(IEfUnitOfWork unitOfWork) { EfUnitOfWork = unitOfWork; }

    private DbSet<TEntity> _objectset;
    protected DbSet<TEntity> ObjectSet { get { return _objectset ?? (_objectset = EfUnitOfWork.Context.Set<TEntity>()); } }

    public TEntity GetById(TKey id) { return ObjectSet.Find(id); }
    public TEntity Create(TEntity entity)
    {
        var result = ObjectSet.Add(entity);
        EfUnitOfWork.Commit();
        return result;
    }
    public void Update(TEntity entity)
    {
        //ObjectSet.Add(entity);  Shawn typed ObjectSet.AddOrUpdate(entity), but ObjectSet doesn't have an AddOrUpdate() method and no other Update() like methods
        //EfUnitOfWork.Commit();
    }
    public void Delete(TEntity entity)
    {
        ObjectSet.Remove(entity);
        EfUnitOfWork.Commit();
    }
    public IList<TEntity> GetAll() { return ObjectSet.Select(o => o).ToList(); }
  }
}