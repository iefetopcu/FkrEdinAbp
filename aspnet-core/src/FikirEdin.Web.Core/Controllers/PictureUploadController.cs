using FikirEdin.Authorization;
using Abp.UI;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Abp.AspNetCore.Mvc.Authorization;

namespace FikirEdin.Controllers
{
    [AbpMvcAuthorize]
    [Route("api/[controller]/[action]")]
    public class PictureUploadController : FikirEdinControllerBase
    {
        private readonly IAppPaths _appPaths;

        public PictureUploadController(IAppPaths appPaths)
        {
            _appPaths = appPaths;
        }     

        [HttpPost]
        public async Task<JsonResult> BlogPicture(IFormFile file)
        {
            if (!await PermissionChecker.IsGrantedAsync(PermissionNames.Pages_Blog))
                throw new UserFriendlyException("You are not authorized!");

            if (file.Length <= 0)
                return Json(string.Empty);

            var mimeType = file.ContentType;
            if (!_appPaths.ImageContentTypes.Contains(mimeType))
                throw new UserFriendlyException(L("UnsupportedFileType"));

            var fileExtension = _appPaths.FileExtension[mimeType];

            var fileName = "blog_" + Guid.NewGuid() + fileExtension;
            var filePath = Path.Combine(_appPaths.BlogPictureFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Json(new { FullPath = _appPaths.SetBlogPictureFolder(fileName), FileName = fileName });
        }

        [HttpPost]
        public async Task<JsonResult> ProductPicture(IFormFile file)
        {
            if (!await PermissionChecker.IsGrantedAsync(PermissionNames.Pages_Product))
                throw new UserFriendlyException("You are not authorized!");

            if (file.Length <= 0)
                return Json(string.Empty);

            var mimeType = file.ContentType;
            if (!_appPaths.ImageContentTypes.Contains(mimeType))
                throw new UserFriendlyException(L("UnsupportedFileType"));

            var fileExtension = _appPaths.FileExtension[mimeType];

            var fileName = "product_" + Guid.NewGuid() + fileExtension;
            var filePath = Path.Combine(_appPaths.ProductPictureFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Json(new { FullPath = _appPaths.SetProductPictureFolder(fileName), FileName = fileName });
        }
    }
}
