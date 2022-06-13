using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace FikirEdin.Web.Views
{
    public abstract class FikirEdinRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected FikirEdinRazorPage()
        {
            LocalizationSourceName = FikirEdinConsts.LocalizationSourceName;
        }
    }
}
