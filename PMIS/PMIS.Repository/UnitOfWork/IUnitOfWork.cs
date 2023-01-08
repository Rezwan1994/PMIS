using PMIS.Repository.Interface.PromotionalProductMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChangesAsync();
        ICategoryInfoRepository ICategoryInfoRepository { get; }

    }
}
