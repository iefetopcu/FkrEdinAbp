using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products.Dto
{
    [AutoMap(typeof(ProductAddLink))]
    public class ProductAddLinkDto : FullAuditedEntityDto
    {
        public string shoppingCentre { get; set; }
        public string salesLink { get; set; }
        public string buttonColor { get; set; }
        public int? productId { get; set; }
        public Product product { get; set; }
    }
}
