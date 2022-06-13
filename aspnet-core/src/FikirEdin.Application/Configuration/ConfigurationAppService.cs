using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FikirEdin.Configuration.Dto;

namespace FikirEdin.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FikirEdinAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
