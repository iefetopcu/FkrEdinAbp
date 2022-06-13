using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Blogs.Dto
{
    [AutoMap(typeof(BlogComment))]
    public class BlogCommentDto : FullAuditedEntityDto
    {
        public string blogCommentDescription { get; set; }
        public string blogCommentSession { get; set; }       
        public int? blogId { get; set; }
        public Blog blog { get; set; }
    }
}
