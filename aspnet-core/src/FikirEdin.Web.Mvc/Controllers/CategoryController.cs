using Abp.Application.Services.Dto;
using FikirEdin.Categories;
using FikirEdin.Categories.Input;
using FikirEdin.Controllers;
using FikirEdin.Web.Models.Category;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FikirEdin.Web.Controllers
{
    public class CategoryController : FikirEdinControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async Task<ActionResult> Index(string url)
        {
            var category = await _categoryAppService.GetCategoryAsync(new GetCategoryInput {url = url});

            var vm = new CategoryViewModel
            {
                Category = category
            };

            return View(vm);
        }

        
    }
}
