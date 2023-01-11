using Microsoft.EntityFrameworkCore;
using PMIS.Repository;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface;
using System.Linq.Expressions;

namespace PMIS.Service.Implementation
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<TEntity>();
        }

        public virtual async Task DeleteAsync(int id)
        {
            _repository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<TEntity> FindAsync(int id)
        {
            return await _repository.GetById(id);
        }


        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.Get(filter).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _repository.Get().ToListAsync();
        }

        //public virtual Task<Pagination<TEntity>> GetAsync(int pageNumber, int pageSize)
        //{
        //    return _repository.GetAsync(pageNumber, pageSize);
        //}

        public virtual async Task InsertAsync(TEntity entity)
        {
            _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task InsertRange(List<TEntity> entities)
        {
            _repository.AddRange(entities);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _repository.Edit(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        //public virtual async Task UpdateRange(List<TEntity> entities)
        //{
        //    _repository.UpdateRange(entities);
        //    await _unitOfWork.SaveChangesAsync();
        //}

        //public virtual async Task AddOrUpdate(TEntity entity)
        //{
        //    _repository.AddOrUpdate(entity);
        //    await _unitOfWork.SaveChangesAsync();
        //}
    }
}