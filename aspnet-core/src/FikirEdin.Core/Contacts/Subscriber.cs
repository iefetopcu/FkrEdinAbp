using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Contacts
{
    [Table("subscriberTable")]
    public class Subscriber : FullAuditedEntity
    {
        public string subscriberEmail { get; set; }
    }
}
