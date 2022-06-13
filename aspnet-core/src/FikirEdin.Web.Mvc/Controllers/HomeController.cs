using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using FikirEdin.Controllers;
using FikirEdin.Products;
using System.Threading.Tasks;
using FikirEdin.Products.Input;
using FikirEdin.Web.Models.Home;
using Microsoft.AspNetCore.Http;
using FikirEdin.Products.Dto;
using Abp.Application.Services.Dto;

namespace FikirEdin.Web.Controllers
{    

    public class HomeController : FikirEdinControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IProductCommentAppService _productCommentAppService;
        private readonly IProductAddLinkAppService _productAddLinkAppService;

        public HomeController(IProductAppService productAppService, IProductCommentAppService productCommentAppService, IProductAddLinkAppService productAddLinkAppService)
        {
            _productAppService = productAppService;
            _productCommentAppService = productCommentAppService;
            _productAddLinkAppService = productAddLinkAppService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Urun(string url)
        {
            var product = await _productAppService.GetSingleProductAsync(new GetSingleProduct { url = url });

            if(product == null)
            {
                return Redirect(ControllerContext.HttpContext.Request.GetTypedHeaders().Referer.ToString());
            }

            //var productCommentRate = await _productCommentAppService.GetAllAsync({productId == product.Id});


            var vm = new SingleProductViewModel
            {

                Product = product
            };



            return View(vm);
        }

        public async Task<ActionResult> Comment(string productCommentName, string productCommentDescription, int productId, int productRate, string modelString)
        {
            await _productCommentAppService.CreateAsync(new ProductCommentDto
            {
                productCommentName = productCommentName,
                productCommentDescription = productCommentDescription,
                productId = productId,
                productRate = productRate,
                modelString = modelString
            });
            return Redirect(ControllerContext.HttpContext.Request.GetTypedHeaders().Referer.ToString());
        }


    }
}
