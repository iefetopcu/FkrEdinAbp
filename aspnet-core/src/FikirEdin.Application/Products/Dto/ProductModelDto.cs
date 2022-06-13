using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products.Dto
{
    [AutoMap(typeof(ProductModel))]
    public class ProductModelDto : FullAuditedEntityDto
    {
        public string productModelName { get; set; }     
        public int? productId { get; set; }
        public Product product { get; set; }
    }
}
