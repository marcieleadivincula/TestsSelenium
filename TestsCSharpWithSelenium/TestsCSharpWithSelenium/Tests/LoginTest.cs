using TestsCSharpWithSelenium.Screens;
using TestsCSharpWithSelenium.Utils;
using Xunit;

namespace TestsCSharpWithSelenium.Tests
{
    public class LoginTest : BaseTest
    {
        private readonly LoginScreen _loginScreen;

        public LoginTest(Browser browser)
        {
            _loginScreen = new LoginScreen(_configuration, browser);
        }

        //Theory: Usado quando passa parâmetros
        [Theory]
        [InlineData(Browser.Chrome, "pri", "teamo")]
        public void DeveRealizarLoginComSucesso(Browser browser, string login, string password)
        {
            
            string response = null;

            try
            {
                loginScreen.LoadScreen(_configuration.GetSection("Selenium:Urls:Login").Value);
                loginScreen.SetText("login", login);
                loginScreen.SetText("senha", password);
                loginScreen.Submit();

                response = loginScreen.GetUserLogin();
                //Outra forma de fazer
                //loginScreen.SetLogin(login);
                //loginScreen.SetPassword(password);

            }
            catch (System.Exception ex)
            {
                //TODO: Tratamento de erro
                throw ex;
            }
            finally
            {
                loginScreen.CloseScreen();
            }

            Assert.True(!string.IsNullOrEmpty(response));
        }
    }
}
