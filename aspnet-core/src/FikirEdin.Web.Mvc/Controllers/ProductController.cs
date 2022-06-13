using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using FikirEdin.Categories;
using FikirEdin.Controllers;
using FikirEdin.Products;
using FikirEdin.Products.Dto;
using FikirEdin.Web.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FikirEdin.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProductController : FikirEdinControllerBase
    {

        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;
        private readonly IProductAddLinkAppService _productAddLinkAppService;
        private readonly IProductModelAppService _productModelAppService;

        public ProductController(ICategoryAppService categoryAppService, IProductAppService productAppService, IProductAddLinkAppService productAddLinkAppService , IProductModelAppService productModelAppService)
        {
            _categoryAppService = categoryAppService;
            _productAppService = productAppService;
            _productAddLinkAppService = productAddLinkAppService;
            _productModelAppService = productModelAppService;
        }

        
        public async Task<IActionResult> Index()
        {
            var vm = new ProductViewModel
            {

            };

            var categories = await _categoryAppService.GetAllAsync(new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 999,
                SkipCount = 0,
                Sorting = "categoryName asc",
            });

            vm.Categories = categories.Items.ToList();


            return View(vm);
        }

        public async Task<IActionResult> Category()
        {
            var vm = new ProductViewModel
            {

            };

            var categories = await _categoryAppService.GetAllAsync(new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 999,
                SkipCount = 0,
                Sorting = "categoryName asc",
            });

            vm.Categories = categories.Items.ToList();

            return View(vm);
        }

        public async Task<ActionResult> EditModalCategory(int id)
        {

            var category = await _categoryAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditProductCategoryModalViewModal
            {
                ProductCategory = category,

            };
            return PartialView("_EditModalCategory", model);
        }

        public async Task<ActionResult> ProductAddLink(int id)
        {

            var product = await _productAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditProductModalViewModal
            {
                Product = product,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ProductAddLink(int productId,string shoppingCentre, string salesLink, string buttonColor)
        {

            

            await _productAddLinkAppService.CreateAsync(new ProductAddLinkDto
            {
                shoppingCentre = shoppingCentre,
                salesLink = salesLink,
                productId = productId,
                buttonColor = buttonColor
            });
            return Redirect(ControllerContext.HttpContext.Request.GetTypedHeaders().Referer.ToString());
        }

        public async Task<ActionResult> ProductAddModel(int id)
        {

            var product = await _productAppService.GetAsync(new EntityDto<int>(id));
            var model = new EditProductModalViewModal
            {
                Product = product,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ProductAddModel(int productId, string modelName)
        {

            await _productModelAppService.CreateAsync(new ProductModelDto
            {
                productModelName = modelName,              
                productId = productId
                
            });
            return Redirect(ControllerContext.HttpContext.Request.GetTypedHeaders().Referer.ToString());
        }
    }
}
