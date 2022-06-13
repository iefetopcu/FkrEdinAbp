using System.Threading.Tasks;
using FikirEdin.Models.TokenAuth;
using FikirEdin.Web.Controllers;
using Shouldly;
using Xunit;

namespace FikirEdin.Web.Tests.Controllers
{
    public class HomeController_Tests: FikirEdinWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}