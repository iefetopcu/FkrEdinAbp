using FikirEdin.Categories.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Helpers
{
    public static class TreeHelper
    {
        public static List<TreeCategoryOutput> CreateTree(List<TreeCategoryOutput> allCategories, int?[] checkedId)
        {
            var lookup = allCategories.Where(a => a.ParentId != 0).ToLookup(category => category.ParentId);

            if (checkedId != null)
                foreach (var ci in allCategories.Where(a => checkedId.Contains(a.Id)).ToList())
                    ci.Checked = true; //secili gelsin mi hmm 

            foreach (var node in allCategories)
                node.Parents = lookup[node.Id].ToList();

            return allCategories.Where(a => a.ParentId == 0).ToList();
        }
    }
}
