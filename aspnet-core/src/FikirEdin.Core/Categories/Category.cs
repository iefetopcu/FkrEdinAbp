using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories
{
    [Table("categoryTable")]
    public class Category : FullAuditedEntity
    {
        public string categoryName { get; set; }
        public int parentid { get; set; }
        public string url { get; set; }
    }
}
