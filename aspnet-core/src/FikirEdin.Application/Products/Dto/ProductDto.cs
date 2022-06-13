using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FikirEdin.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products.Dto
{
    [AutoMap(typeof(Product))]
    public class ProductDto : FullAuditedEntityDto
    {
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string url { get; set; }
        public virtual string Picture { get; set; }
        public int productViewCount { get; set; }
        public bool productShowcase { get; set; }
        public bool isActive { get; set; }
        public int categoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
