using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using FikirEdin.Controllers;

namespace FikirEdin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : FikirEdinControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
