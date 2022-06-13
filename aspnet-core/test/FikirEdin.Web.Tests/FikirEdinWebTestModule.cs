using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FikirEdin.EntityFrameworkCore;
using FikirEdin.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FikirEdin.Web.Tests
{
    [DependsOn(
        typeof(FikirEdinWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FikirEdinWebTestModule : AbpModule
    {
        public FikirEdinWebTestModule(FikirEdinEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FikirEdinWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FikirEdinWebMvcModule).Assembly);
        }
    }
}