using System.Collections.Generic;
using FikirEdin.Roles.Dto;

namespace FikirEdin.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}