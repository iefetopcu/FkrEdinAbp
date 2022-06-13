using Abp.AspNetCore.Mvc.ViewComponents;

namespace FikirEdin.Web.Views
{
    public abstract class FikirEdinViewComponent : AbpViewComponent
    {
        protected FikirEdinViewComponent()
        {
            LocalizationSourceName = FikirEdinConsts.LocalizationSourceName;
        }
    }
}
