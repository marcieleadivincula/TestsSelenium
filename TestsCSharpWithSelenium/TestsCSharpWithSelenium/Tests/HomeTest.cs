using TestsCSharpWithSelenium.Screens;
using TestsCSharpWithSelenium.Utils;
using Xunit;

namespace TestsCSharpWithSelenium.Tests
{
    public class HomeTest : BaseTest
    {
        //Theory: Usado quando passa parâmetros
        [Theory]
        [InlineData(Browser.Chrome)]
        public void DeveCarregarTelaHomeComSucesso(Browser browser)
        {
            HomeScreen homeScreen = new HomeScreen(_configuration, browser);
            string response;

            try
            {
                homeScreen.LoadScreen(_configuration.GetSection("Selenium:Urls:Home").Value);
                response = homeScreen.GetServices();
            }
            catch (System.Exception ex)
            {
                //TODO: Tratamento de erro
                throw ex;
            }
            finally
            {
                homeScreen.CloseScreen();
            }

            Assert.True(!string.IsNullOrEmpty(response));
        }
    }
}
