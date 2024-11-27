using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositories;

public class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TContext : DbContext
{
    protected TContext Context { get; }    //Sadece okuma yapmasını isteriz. Protecected ile sadece miras alınanlar için.

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        await Context.Set<TEntity>().AddAsync(entity);         //İlgili tabloyu bulmakta set
        await Context.SaveChangesAsync();

        return entity;
    }
    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableAutoInclude = true)  //.net 8 
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (filter is not null)
        {
            query = query.Where(filter);
        }
        if (enableAutoInclude == false)
        {
            query = query.IgnoreAutoIncludes();
        }

        return query.ToList();
    }
    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return Context.Set<TEntity>().Find(id);
    }
    public async Task<TEntity?> RemoveAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.Now;
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}
