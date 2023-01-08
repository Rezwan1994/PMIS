using PMIS.Repository.Interface.ProductPromotionalMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;


        ICategoryInfoRepository ICategoryInfoRepository { get; }
    }
}
