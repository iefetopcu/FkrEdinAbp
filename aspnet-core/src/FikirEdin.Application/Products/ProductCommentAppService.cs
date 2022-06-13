using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using FikirEdin.Products.Dto;
using FikirEdin.Products.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    public interface IProductCommentAppService : IAsyncCrudAppService<ProductCommentDto>
    {
        Task<ProductCommentDto> CreateAsync(ProductCommentDto input);
        

    }

    public class ProductCommentAppService : AsyncCrudAppService<ProductComment, ProductCommentDto>, IProductCommentAppService
    {
        public ProductCommentAppService(IRepository<ProductComment, int> repository) : base(repository)
        {
        }

        public override Task<ProductCommentDto> CreateAsync(ProductCommentDto input)
        {
            input.approved = false;
            return base.CreateAsync(input);
        }

        

    }
}
