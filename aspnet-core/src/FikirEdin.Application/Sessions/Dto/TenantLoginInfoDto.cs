using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using FikirEdin.MultiTenancy;

namespace FikirEdin.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
