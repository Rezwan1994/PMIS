using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMIS.Domain.Entities;
using PMIS.Repository.Implementation;
using PMIS.Repository.Interface;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Implementation;
using PMIS.Service.Implementation.PromotionalProductMaterial;
using PMIS.Service.Implementation.Security;
using PMIS.Service.Interface;
using PMIS.Service.Interface.PromotionalProductMaterial;
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
                options.UseOracle(connectionString, options => options
                    .UseOracleSQLCompatibility("11"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<ICommonServices, CommonServices>();
            services.AddTransient<ILogError, LogError>();

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
            services.AddTransient<IReportConfigurationService, ReportConfigurationService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            #endregion

            #region PromotionalProductMaterial
            services.AddTransient<ICategoryInfoService, CategoryInfoService>();
            services.AddTransient<IPMInfoService, PMInfoService>();

            services.AddTransient<ISbuService, SbuService>();

            services.AddTransient<IDoctorCategoryService, DoctorCategoryService>();

            #endregion

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
