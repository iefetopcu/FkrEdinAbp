using System.Collections.Generic;
using FikirEdin.Roles.Dto;

namespace FikirEdin.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
