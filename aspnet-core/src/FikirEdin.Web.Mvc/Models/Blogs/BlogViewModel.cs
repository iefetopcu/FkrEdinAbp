using FikirEdin.Categories.Dto;
using System.Collections.Generic;

namespace FikirEdin.Web.Models.Blogs
{
    public class BlogViewModel
    {
        public List<BlogCategoryDto> Categories { get; set; }
    }
}
