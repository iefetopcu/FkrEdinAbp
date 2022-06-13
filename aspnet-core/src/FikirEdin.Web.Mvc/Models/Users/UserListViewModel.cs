using System.Collections.Generic;
using FikirEdin.Roles.Dto;

namespace FikirEdin.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
