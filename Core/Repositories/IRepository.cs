using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repositories;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableAutoInclude = true);   //Lambda işlemi yapılacaksa ona göre filtreleme yapmamızı sağlar. Filtreleme sonucu bool değer olacak.
    Task<TEntity?> GetByIdAsync(TId id);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<TEntity?> AddAsync(TEntity entity);
    Task<TEntity?> RemoveAsync(TEntity entity);

}
