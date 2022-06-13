using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Contacts
{
    [Table("contactTable")]
    public class Contact : FullAuditedEntity
    {
        public string nameSurname { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime createtime { get; set; }
        public int status { get; set; }
    }
}
