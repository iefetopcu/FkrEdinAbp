using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FikirEdin.Controllers
{
    public abstract class FikirEdinControllerBase: AbpController
    {
        protected FikirEdinControllerBase()
        {
            LocalizationSourceName = FikirEdinConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
