using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using FikirEdin.Categories.Dto;
using FikirEdin.Categories.Input;
using FikirEdin.Categories.Outputs;
using FikirEdin.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto>
    {
        Task<List<TreeCategoryOutput>> GetTreeCategories();
        Task<CategoryDto> GetCategoryAsync(GetCategoryInput input);
    }

    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto>, ICategoryAppService
    {
        private readonly ICategoryDomainService _categoryDomainService;
        private readonly IRepository<Category> _category;


        public CategoryAppService(IRepository<Category, int> repository, ICategoryDomainService categoryDomainService) : base(repository)
        {
            _categoryDomainService = categoryDomainService;
        }

        public override Task<CategoryDto> CreateAsync(CategoryDto input)
        {
            if(input.parentid != 0)
            {
                var findparentcat = _category.GetAll().Where(a => a.Id == input.parentid).FirstOrDefault();
                var parentName = string.IsNullOrEmpty(findparentcat.categoryName.Trim()) ? Utility.UrlSeo(findparentcat.categoryName.Trim()) : Utility.UrlSeo(findparentcat.categoryName.Trim());
                var catname = string.IsNullOrEmpty(input.categoryName.Trim()) ? Utility.UrlSeo(input.categoryName.Trim()) : Utility.UrlSeo(input.categoryName.Trim());
                input.url = parentName + "-" + catname;
            }
            else
            {
                var catname = string.IsNullOrEmpty(input.categoryName.Trim()) ? Utility.UrlSeo(input.categoryName.Trim()) : Utility.UrlSeo(input.categoryName.Trim());
                input.url = catname;
            }



            
            
            
            
            
            return base.CreateAsync(input);
        }

        public async Task<CategoryDto> GetCategoryAsync(GetCategoryInput input)
        {
            var product = await Repository.GetAll().Where(a => a.url == input.url).FirstOrDefaultAsync();
            return ObjectMapper.Map<CategoryDto>(product);
        }

        public async Task<List<TreeCategoryOutput>> GetTreeCategories()
        {
            var result = await _categoryDomainService.GetTreeCategory();
            return result;
        }
    }
}
