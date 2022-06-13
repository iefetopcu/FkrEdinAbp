using Abp.Application.Services;
using Abp.Domain.Repositories;
using FikirEdin.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories
{
    public interface IBlogCategoryAppService : IAsyncCrudAppService<BlogCategoryDto>
    {
    }

    public class BlogCategoryAppService : AsyncCrudAppService<BlogCategory, BlogCategoryDto>, IBlogCategoryAppService
    {
        public BlogCategoryAppService(IRepository<BlogCategory, int> repository) : base(repository)
        {
        }
    }
}
