using Abp.Application.Services;
using Abp.Domain.Repositories;
using FikirEdin.Blogs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Blogs
{
    internal interface IBlogCommentAppService : IAsyncCrudAppService<BlogCommentDto>
    {

    }

    public class BlogCommentAppService : AsyncCrudAppService<BlogComment, BlogCommentDto>, IBlogCommentAppService
    {
        public BlogCommentAppService(IRepository<BlogComment, int> repository) : base(repository)
        {
        }
    }
}
