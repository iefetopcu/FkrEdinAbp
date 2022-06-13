using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FikirEdin.Categories;
using FikirEdin.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Blogs.Dto
{
    [AutoMap(typeof(Blog))]
    public class BlogDto : FullAuditedEntityDto
    {
        public string blogTitle { get; set; }
        public string blogDescription { get; set; }
        public virtual string Picture { get; set; }
        public string url { get; set; }
        public string blogSpotText { get; set; }
        public int blogViewCount { get; set; }
        public DateTime releaseTime { get; set; }
        public int blogCategoryId { get; set; }
        public BlogCategoryDto BlogCategory { get; set; }
    }
}
