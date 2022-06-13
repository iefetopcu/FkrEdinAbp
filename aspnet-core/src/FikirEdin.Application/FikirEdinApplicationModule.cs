using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FikirEdin.Authorization;

namespace FikirEdin
{
    [DependsOn(
        typeof(FikirEdinCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FikirEdinApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FikirEdinAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FikirEdinApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
