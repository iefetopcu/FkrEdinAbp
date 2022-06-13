using Abp.Domain.Repositories;
using Abp.Domain.Services;
using FikirEdin.Categories.Outputs;
using FikirEdin.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FikirEdin.Categories
{
    public interface ICategoryDomainService : IDomainService
    {
        Task<List<TreeCategoryOutput>> GetTreeCategory();
    }

    public class CategoryDomainService : DomainService, ICategoryDomainService
    {
        private readonly IRepository<Category> _category;

        public CategoryDomainService(IRepository<Category> category)
        {
            _category = category;
        }

        public async Task<List<TreeCategoryOutput>> GetTreeCategory()
        {
            var allCategories = await _category.GetAll().Select(a => new TreeCategoryOutput
            {
                Id = a.Id,
                Url = a.url,
                Checked = false,
                Name = a.categoryName,
                ParentId = a.parentid,
                Parents = new List<TreeCategoryOutput>(),
            }).ToListAsync();

            var result = TreeHelper.CreateTree(allCategories, null);
            return result;
        }
    }
}
