using Abp.Domain.Entities.Auditing;
using FikirEdin.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Blogs
{
    [Table("blogTable")]
    public class Blog : FullAuditedEntity
    {
        public string blogTitle { get; set; }
        public string blogDescription { get; set; }
        public string url { get; set; }
        public virtual string Picture { get; set; }
        public string blogSpotText { get; set; }
        public int blogViewCount { get; set; }
        public DateTime releaseTime { get; set; }
        [ForeignKey("blogCategoryId")]
        public int blogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }

    }
}
