using Abp.Application.Services;
using Abp.Domain.Repositories;
using FikirEdin.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    public interface IProductAddLinkAppService : IAsyncCrudAppService<ProductAddLinkDto>
    {
    }

    public class ProductAddLinkAppService : AsyncCrudAppService<ProductAddLink, ProductAddLinkDto>, IProductAddLinkAppService
    {
        public ProductAddLinkAppService(IRepository<ProductAddLink, int> repository) : base(repository)
        {
        }
    }
}
