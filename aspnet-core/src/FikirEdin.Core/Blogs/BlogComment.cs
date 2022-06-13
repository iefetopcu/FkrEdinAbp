using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Blogs
{
    [Table("blogCommentTable")]
    public class BlogComment : FullAuditedEntity
    {
        public string blogCommentDescription { get; set; }
        public string blogCommentSession { get; set; }
        [ForeignKey("blogId")]
        public int? blogId { get; set; }
        public Blog blog { get; set; }
    }
}
