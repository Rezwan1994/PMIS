using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PMIS.Domain.Entities;

namespace PMIS.Domain.DBContext
{
    public partial class PMISDbContext : ModelContext
    {
        public PMISDbContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }
    }
}
