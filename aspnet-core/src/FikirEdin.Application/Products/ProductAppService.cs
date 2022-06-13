using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Extensions;
using Abp.Linq.Extensions;
using FikirEdin.Authorization;
using FikirEdin.Categories;
using FikirEdin.Helpers;
using FikirEdin.Products.Dto;
using FikirEdin.Products.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    // CRUD SERVISLERI
    
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, ProductGettAllInput> 
    {
        Task<ProductDto> GetSingleProductAsync(GetSingleProduct input);
    }

    //[AbpAuthorize(PermissionNames.Pages_Product)]
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, ProductGettAllInput> , IProductAppService
    {
        private readonly IRepository<Category> _category;

        public ProductAppService(IRepository<Product, int> repository, IRepository<Category> category) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_Product;
            UpdatePermissionName = PermissionNames.Pages_Product;
            DeletePermissionName = PermissionNames.Pages_Product;
            _category = category;
            //GetPermissionName = PermissionNames.Pages_Product;
            //GetAllPermissionName = PermissionNames.Pages_Product;                   
        }

        public override async Task<ProductDto> GetAsync(EntityDto<int> input )
        {
            var product = await Repository.GetAll().Where(a => a.Id == input.Id).Include(a => a.Category).FirstOrDefaultAsync();
            return ObjectMapper.Map<ProductDto>(product);
            //return base.GetAsync(input);
        }

        //Search Mantığı
        protected override IQueryable<Product> CreateFilteredQuery(ProductGettAllInput input)
        {
            //return base.CreateFilteredQuery(input)
            //    .Include(a => a.Category)
            //    .IncludeIf(input.IsIncludePhotos, a => a.Photos)               
            //    .WhereIf(!string.IsNullOrEmpty(input.productName), a => a.productName.Contains(input.productName));

            return base.CreateFilteredQuery(input)
               .Include(a => a.Category)        
               .WhereIf(input.CategoryId.HasValue, a => a.categoryId == input.CategoryId)
               .WhereIf(!string.IsNullOrEmpty(input.productName), a => a.productName.Contains(input.productName));
        }
        public async Task<ProductDto> GetSingleProductAsync(GetSingleProduct input)
        {
            
            var product = await Repository.GetAll().Where(a => a.url == input.url).Include(a => a.Category).FirstOrDefaultAsync();
            return ObjectMapper.Map<ProductDto>(product);
        }

        public override Task<ProductDto> CreateAsync(ProductDto input)
        {
            var product = _category.GetAll().Where(a => a.Id == input.categoryId).FirstOrDefault();
            var seourlcat = string.IsNullOrEmpty(product.categoryName.Trim()) ? Utility.UrlSeo(product.categoryName.Trim()) : Utility.UrlSeo(product.categoryName.Trim());
            var seourl = string.IsNullOrEmpty(input.productName.Trim()) ? Utility.UrlSeo(input.productName.Trim()) : Utility.UrlSeo(input.productName.Trim());
            input.url = seourlcat+"_"+seourl;
            return base.CreateAsync(input);
        }
    
        public async Task<List<Product>> GetProducts(GetProductInput input)
        {
            var catIds = new List<int>();
            catIds = await GetSubCategories(input.CategoryId, catIds);

            var allProducts = await Repository.GetAll().Where(a => catIds.Contains(a.categoryId)).ToListAsync();
            return allProducts;
        }

        private async Task<List<int>> GetSubCategories(int categoryId, List<int> ids)
        {
            var catId = await _category.GetAll().FirstOrDefaultAsync(a => a.parentid == categoryId);
            ids.Add(catId.Id);
            if (catId.parentid > 0)
                await GetSubCategories(catId.parentid, ids);

            return ids;
        }
    }
}
