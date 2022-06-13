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
    public interface IProductModelAppService : IAsyncCrudAppService<ProductModelDto>
    {

    }

    public class ProductModelAppService : AsyncCrudAppService<ProductModel, ProductModelDto>, IProductModelAppService
    {
        public ProductModelAppService(IRepository<ProductModel, int> repository) : base(repository)
        {
        }
    }
}
