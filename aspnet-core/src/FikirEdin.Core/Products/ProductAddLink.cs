using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    [Table("productAddLinkTable")]
    public class ProductAddLink : FullAuditedEntity
    {
        public string shoppingCentre { get; set; }
        public string salesLink { get; set; }
        public string buttonColor { get; set; }
        [ForeignKey("productId")]
        public int? productId { get; set; }
        public Product product { get; set; }
    }
}

