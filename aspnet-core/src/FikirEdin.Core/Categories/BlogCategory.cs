using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories
{
    [Table("blogCategoryTable")]
    public class BlogCategory : FullAuditedEntity
    {
        public string categoryName { get; set; }
    }
}
