using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories.Dto
{
    [AutoMap(typeof(BlogCategory))]
    public class BlogCategoryDto : FullAuditedEntityDto
    {
        public string categoryName { get; set; }
    }
}
