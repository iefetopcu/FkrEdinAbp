using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FikirEdin.Configuration;

namespace FikirEdin.Web.Host.Startup
{
    [DependsOn(
       typeof(FikirEdinWebCoreModule))]
    public class FikirEdinWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FikirEdinWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FikirEdinWebHostModule).GetAssembly());
        }
    }
}
