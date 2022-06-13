using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using FikirEdin.Authorization;
using FikirEdin.Blogs.Dto;
using FikirEdin.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Blogs
{
    public interface IBlogAppService : IAsyncCrudAppService<BlogDto>
    {

    }


    public class BlogAppService : AsyncCrudAppService<Blog, BlogDto>, IBlogAppService
    {
        public BlogAppService(IRepository<Blog, int> repository) : base(repository)
        {
        }

        public override async Task<BlogDto> GetAsync(EntityDto<int> input)
        {
            var blog = await Repository.GetAll().Where(a => a.Id == input.Id).Include(a => a.BlogCategory).FirstOrDefaultAsync();
            return ObjectMapper.Map<BlogDto>(blog);
        }

        protected override IQueryable<Blog> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(a => a.BlogCategory);
        }
        public override Task<BlogDto> CreateAsync(BlogDto input)
        {
            var seourl = string.IsNullOrEmpty(input.blogTitle.Trim()) ? Utility.UrlSeo(input.blogTitle.Trim()) : Utility.UrlSeo(input.blogTitle.Trim());
            input.url = seourl;
            return base.CreateAsync(input);
        }
    }

    
    
}
