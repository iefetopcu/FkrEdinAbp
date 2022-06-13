using System.Threading.Tasks;
using FikirEdin.Configuration.Dto;

namespace FikirEdin.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
