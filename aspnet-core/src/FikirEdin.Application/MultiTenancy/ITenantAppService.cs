using Abp.Application.Services;
using FikirEdin.MultiTenancy.Dto;

namespace FikirEdin.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

