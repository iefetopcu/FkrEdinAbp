using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Products.Input
{
    public class ProductGettAllInput : PagedAndSortedResultRequestDto
    {
        public string productName { get; set; }
        public bool IsIncludePhotos { get; set; }
        public int? CategoryId { get; set; }
        public string url { get; set; }

    }
}
