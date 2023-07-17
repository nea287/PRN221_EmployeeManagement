using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Services;
using EmployeeManagement_SWD392.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace EmployeeManagement.Properties.AppStart
{
    public static class DenpendencyInjection
    {

        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddScoped<SWD392_EmployeeManagementContext>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IManagerService, ManagerService>();
        }
    }
}
