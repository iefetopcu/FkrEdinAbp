using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using FikirEdin.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    [Table("productsTable")]
    public class Product : FullAuditedEntity
    {
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string url { get; set; }
        public virtual string Picture { get; set; }
        public int productViewCount { get; set; }
        public bool productShowcase { get; set; }
        public bool isActive { get; set; }      
        [ForeignKey("categoryId")]
        public int categoryId { get; set; }
        public Category Category { get; set; }
        
    }
}
