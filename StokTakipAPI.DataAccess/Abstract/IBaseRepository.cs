using Microsoft.EntityFrameworkCore.Query;
using StokTakipAPI.Model.Entity;
using System.Linq.Expressions;

namespace StokTakipAPI.DataAccess.Abstract;
public interface IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    void Add(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    TEntity GetById(TId id,Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include=null);
    TEntity GetByFilter(Expression<Func<TEntity, bool>> filter,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null!,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);

}
