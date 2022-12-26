using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMIS.Domain.DBContext;
using PMIS.Repository.Implementation;
using PMIS.Repository.Interface;
using PMIS.Service.Implementation.Security;
using PMIS.Service.Interface.Security;
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

            services.AddTransient<ICommonServices, CommonServices>();

            #region Security
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IMenuPermissionService, MenuPermissionService>();
            services.AddTransient<IMenuMasterService, MenuMasterService>();
            services.AddTransient<IMenuCategoryService, MenuCategoryService>();
            services.AddTransient<IMenuPermissionService, MenuPermissionService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserMenuConfigService, UserMenuConfigService>();
            services.AddTransient<IUserLogService, UserLogService>();
            #endregion

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
