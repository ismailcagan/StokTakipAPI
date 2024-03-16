using Microsoft.EntityFrameworkCore.Query;
using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.DataAccess.Context;
using StokTakipAPI.Model.Entity;
using System.Linq.Expressions;

namespace StokTakipAPI.DataAccess.Concrete;
public class BaseRepository<TContext, TEntity, TId> : IBaseRepository<TEntity, TId>, IQuery<TEntity>
    where TEntity : BaseEntity<TId>
    where TContext : BaseDbContext
{
    protected TContext Context { get; set; }
    public BaseRepository(TContext context)
    {
        Context = context;
    }
    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if(filter is not null)
        {
            queryable = queryable.Where(filter);
        }
        if(include is not null)
        {
            queryable = include(queryable);
        }
        return queryable.ToList();
    }

    public TEntity GetByFilter(Expression<Func<TEntity, bool>> filter, 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable = queryable.Where(filter);
        if(include is not null)
        {
            queryable = include(queryable);
        }
        return queryable.FirstOrDefault();
    }

    public TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if(include is not null)
        {
            queryable=include(queryable);
        }
        return queryable.SingleOrDefault(x => x.Equals(id));
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
    }
}
