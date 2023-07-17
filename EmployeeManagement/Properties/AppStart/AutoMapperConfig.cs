using AutoMapper;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.Request.Account;
using EmployeeManagement_BusinessLayer.Request.Benefit;
using EmployeeManagement_BusinessLayer.Request.Employee;
using EmployeeManagement_BusinessLayer.ViewModels;
using EmployeeManagement_SWD392.Models;

namespace EmployeeManagement.Properties.AppStart
{
    public static class ObjectModule
    {
        public static void ConfigObjectMapperModule(this IMapperConfigurationExpression mc)
        {
            //Account
            mc.CreateMap<Account, AccountViewModel>().ReverseMap();
            mc.CreateMap<Account, CreateAccountRequestModel>().ReverseMap();
            mc.CreateMap<Account, UpdateAccountRequestModel>().ReverseMap();
            mc.CreateMap<CreateAccountRequestModel, AccountViewModel>().ReverseMap();
            mc.CreateMap<UpdateAccountRequestModel, AccountViewModel>().ReverseMap();
            mc.CreateMap<UpdateAccountByManagerRequestModel, AccountViewModel>().ReverseMap();
            mc.CreateMap<UpdateAccountByManagerRequestModel, Account>().ReverseMap();
            mc.CreateMap<UpdateAccountByManagerRequestModel, UpdateAccountRequestModel>();
            //Employee
            mc.CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            mc.CreateMap<Employee, CreateEmployeeRequestModel>().ReverseMap();
            mc.CreateMap<Employee, UpdateEmployeeRequestModel>().ReverseMap();
            mc.CreateMap<EmployeeViewModel, CreateEmployeeRequestModel>().ReverseMap();
            mc.CreateMap<EmployeeViewModel, UpdateEmployeeRequestModel>().ReverseMap();

            //Benefit
            mc.CreateMap<Benefit, BenefitViewModel>().ReverseMap();
            mc.CreateMap<Benefit, BenefitRequestModel>().ReverseMap();
            mc.CreateMap<Benefit, UpdateBenefitRequestModel>().ReverseMap();
            mc.CreateMap<BenefitViewModel, BenefitRequestModel>().ReverseMap();
            mc.CreateMap<BenefitViewModel, UpdateBenefitRequestModel>().ReverseMap();


        }
    }
    public static class AutoMapperConfig

    {
        public static void AutoMapperModule(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperResolver());
                mc.ConfigObjectMapperModule();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
