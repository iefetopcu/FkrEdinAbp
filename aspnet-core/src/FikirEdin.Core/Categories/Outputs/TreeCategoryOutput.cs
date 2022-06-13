using System.Collections.Generic;

namespace FikirEdin.Categories.Outputs
{
    public class TreeCategoryOutput
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<TreeCategoryOutput> Parents { get; set; }
        public bool Checked { get; internal set; }
    }
}
