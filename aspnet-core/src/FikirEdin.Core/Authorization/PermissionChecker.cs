using Abp.Authorization;
using FikirEdin.Authorization.Roles;
using FikirEdin.Authorization.Users;

namespace FikirEdin.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
