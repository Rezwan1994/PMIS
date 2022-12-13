using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMIS.Domain.DBContext;
using PMIS.Repository.Implementation;
using PMIS.Repository.Interface;
using PMIS.Service.Implementation.Security;
using PMIS.Service.Interface.Security.Company;
using PMIS.Service.Interface.Security.Security;
using PMIS.Service.Interface.Security.User;
using PMIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.IOC
{
    public static class ServiceInstance
    {
        public static void RegisterServiceInstance(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(PMISDbContext));
            services.AddDbContextPool<PMISDbContext>(options =>
                options.UseOracle(connectionString)
            );

            services.AddTransient<ICompanyManager, CompanyManager>();
            services.AddTransient<ICommonServices, CommonServices>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IMenuPermissionManager, MenuPermissionManager>();
            services.AddTransient<IMenuCategoryManager, MenuCategoryManager>();
            services.AddTransient<IMenuPermissionManager, MenuPermissionManager>();
            services.AddTransient<IUserMenuConfigManager, UserMenuConfigManager>();
            services.AddTransient<IMenuMasterManager, MenuMasterManager>();
            services.AddTransient<INotificationManager, NotificationManager>();
            services.AddTransient<IUserLogManager, UserLogManager>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
