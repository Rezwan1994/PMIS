using PMIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface
{
    public interface IBaseService<TEntity>
    {
     
        Task<IEnumerable<TEntity>> GetAsync();
        //Task<Pagination<TEntity>> GetAsync(int pageNumber, int pageSize);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindAsync(int id);
        //Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);
        Task InsertAsync(TEntity entity);
        Task InsertRange(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(TEntity entity);
        //Task AddOrUpdate(TEntity entity);

    }
}
