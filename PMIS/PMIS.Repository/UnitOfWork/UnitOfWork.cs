using Microsoft.EntityFrameworkCore;
using PMIS.Domain.DBContext;
using PMIS.Repository.Implementation;
using PMIS.Repository.Implementation.ProductPromotionalMaterial;
using PMIS.Repository.Interface.ProductPromotionalMaterial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly PMISDbContext _dbContext;
        private readonly Hashtable _repositories;
        public UnitOfWork(PMISDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }

        public virtual void Dispose() => _dbContext?.Dispose();
        public virtual Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();
        private ICategoryInfoRepository _categoryInfoRepository;

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                _repositories.Add(type, new Repository<TEntity>(_dbContext));
            }
            return (IRepository<TEntity>)_repositories[type];
        }

        public ICategoryInfoRepository ICategoryInfoRepository
        {
            get
            {
                if (ICategoryInfoRepository == null)
                {
                    this._categoryInfoRepository = new CategoryInfoRepository(_dbContext);
                }
                return _categoryInfoRepository;
            }
        }


    }
}
