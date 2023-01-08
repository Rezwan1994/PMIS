using Microsoft.EntityFrameworkCore;
using PMIS.Domain.DBContext;
using PMIS.Domain.Entities;
using PMIS.Repository.Interface.PromotionalProductMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.Implementation.PromotionalProductMaterial
{
    public class CategoryInfoRepository: Repository<PM_CATEGORY_INFO>, ICategoryInfoRepository
    {
        public CategoryInfoRepository(PMISDbContext context) : base(context)
        {
        }
    }
}
