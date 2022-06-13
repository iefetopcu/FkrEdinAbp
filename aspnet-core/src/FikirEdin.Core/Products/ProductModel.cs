using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products
{
    [Table("productModelTable")]

    public class ProductModel : FullAuditedEntity
    {
        public string productModelName { get; set; }
        [ForeignKey("productId")]
        public int? productId { get; set; }
        public Product product { get; set; }
    }
}
