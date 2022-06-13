using Abp.AspNetCore.Mvc.Authorization;
using FikirEdin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FikirEdin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class DashboardController : FikirEdinControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
