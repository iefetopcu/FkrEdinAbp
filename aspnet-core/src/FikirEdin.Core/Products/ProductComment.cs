using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    [Table("productCommentTable")]
    public class ProductComment : FullAuditedEntity
    {
        public string productCommentName { get; set; }
        public int productCommentLike { get; set; }
        public string productCommentDescription { get; set; }
        public string productCommentSession { get; set; }
        public string modelString { get; set; }
        public int productRate { get; set; }
        public Boolean approved { get; set; }
        [ForeignKey("productId")]
        public int? productId { get; set; }
        public Product product { get; set; }

        
    }
}
