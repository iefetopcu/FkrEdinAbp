using System.Threading.Tasks;
using Abp.Application.Services;
using FikirEdin.Sessions.Dto;

namespace FikirEdin.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
