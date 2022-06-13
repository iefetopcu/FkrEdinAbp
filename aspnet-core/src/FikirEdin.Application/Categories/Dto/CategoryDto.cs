using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories.Dto
{
    [AutoMap(typeof(Category))]
    public class CategoryDto : FullAuditedEntityDto
    {
        public string categoryName { get; set; }
        public int parentid { get; set; }
        public string url { get; set; }

    }
}
