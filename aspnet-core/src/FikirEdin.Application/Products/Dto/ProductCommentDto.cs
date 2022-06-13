using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products.Dto
{
    [AutoMap(typeof(ProductComment))]
    public class ProductCommentDto : FullAuditedEntityDto
    {
        public string productCommentName { get; set; }
        public int productCommentLike { get; set; }
        public string productCommentDescription { get; set; }
        public string productSession { get; set; }
        public string modelString { get; set; }
        public int productRate { get; set; }
        public int? productId { get; set; }
        public Boolean approved { get; set; }
        public ProductDto product { get; set; }
        
    }
}
