using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using FikirEdin.Categories;
using FikirEdin.Categories.Dto;
using FikirEdin.Controllers;
using FikirEdin.Web.Models.Blogs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FikirEdin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class BlogController : FikirEdinControllerBase
    {
        private readonly IBlogCategoryAppService _blogCategoryAppService;

        public BlogController(IBlogCategoryAppService blogCategoryAppService)
        {
            _blogCategoryAppService = blogCategoryAppService;
        }


        public async Task<IActionResult> Index()
        {
            var vm = new BlogViewModel
            {
                
            };

            var categories = await _blogCategoryAppService.GetAllAsync(new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 999,
                SkipCount = 0,
                Sorting = "categoryName asc",
            });

            vm.Categories = categories.Items.ToList();

            return View(vm);
        }

        public ActionResult Category()
        {          
            return View();
        }

        public async Task<ActionResult> EditModalCategory(int id)
        {
            var blog = await _blogCategoryAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditBlogCategoryModalViewModal
            {
                BlogCategory = blog,
                
            };
            return PartialView("_EditModalCategory", model);
        }

    }
}
