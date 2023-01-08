using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(List<TEntity> entity);
        void Remove(int id);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToUpdate);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> GetById(int id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
        (IList<TEntity> data, int total, int totalDisplay) Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        //(IList<TEntity> data, int total, int totalDisplay) GetDynamic(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    string orderBy = null,
        //    string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool isTrackingOff = false);

        //IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null,
        //    string orderBy = null,
        //    string includeProperties = "", bool isTrackingOff = false);
    }
}
