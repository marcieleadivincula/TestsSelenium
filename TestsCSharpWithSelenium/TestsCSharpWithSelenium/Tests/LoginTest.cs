using System;
using TestsCSharpWithSelenium.Screens;
using TestsCSharpWithSelenium.Utils;
using Xunit;

namespace TestsCSharpWithSelenium.Tests
{
    public class LoginTest : BaseTest
    {
        private readonly LoginScreen _loginScreen;

        public LoginTest()
        {
            _loginScreen = new LoginScreen(_configuration, Browser.Chrome);
        }

        //Theory: Usado quando passa parâmetros
        [Theory]
        [InlineData("pri", "teamo")]
        public void DeveRealizarLoginComSucesso(string login, string password)
        {
            string response = null;
            string response2 = null;
            const string expected = "PRISCILA ALVES ANTUNES BEM VINDO...";

            try
            {
                _loginScreen.LoadScreen(_configuration.GetSection("Selenium:Urls:Login").Value);
                _loginScreen.SetText("login", login);
                _loginScreen.SetText("senha", password);
                _loginScreen.Submit();
                response = _loginScreen.GetUserLogin();
                _loginScreen.TakePrintScreenImageFormatPng(@"c:\Screenshot\DeveRealizarLoginComSucesso\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.png");
                _loginScreen.TakePrintScreenImageFormatJpeg(@"c:\Screenshot\DeveRealizarLoginComSucesso\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Jpeg");
                _loginScreen.TakePrintScreenImageFormatBmp(@"c:\Screenshot\DeveRealizarLoginComSucesso\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Bmp");
                _loginScreen.TakePrintScreenImageFormatGif(@"c:\Screenshot\DeveRealizarLoginComSucesso\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Gif");
                _loginScreen.TakePrintScreenImageFormatTiff(@"c:\Screenshot\DeveRealizarLoginComSucesso\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Tiff");

                //Outra forma de fazer
                _loginScreen.SetLogin(login);
                _loginScreen.SetPassword(password);
                _loginScreen.Submit();
                response2 = _loginScreen.GetUserLogin();
            }
            catch (System.Exception ex)
            {
                //TODO: Tratamento de erro
                throw ex;
            }
            finally
            {
                _loginScreen.CloseScreen();
            }

            Assert.True(!string.IsNullOrEmpty(response));
            Assert.True(!string.IsNullOrEmpty(response2));
            Assert.Equal(response, expected);
            Assert.Equal(response2, expected);
        }

        [Theory]
        [InlineData("pri", "senha_errada")]
        [InlineData("usuario_errado", "teamo")]
        [InlineData("usuario_errado", "senha_errada")]
        public void DeveExibirUmaMensagemErroQuandoUsuarioSenhaInvalido(string login, string password)
        {
            string response = null;
            const string expected = "Usuário ou Senha não encontrado!";

            try
            {
                _loginScreen.LoadScreen(_configuration.GetSection("Selenium:Urls:Login").Value);
                _loginScreen.SetText("login", login);
                _loginScreen.SetText("senha", password);
                _loginScreen.Submit();

                response = _loginScreen.GetErrorMessage();
                _loginScreen.TakePrintScreenImageFormatPng(@"c:\Screenshot\DeveExibirUmaMensagemErroQuandoUsuarioSenhaInvalido\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Png");
                _loginScreen.TakePrintScreenImageFormatJpeg(@"c:\Screenshot\DeveExibirUmaMensagemErroQuandoUsuarioSenhaInvalido\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Jpeg");
                _loginScreen.TakePrintScreenImageFormatBmp(@"c:\Screenshot\DeveExibirUmaMensagemErroQuandoUsuarioSenhaInvalido\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Bmp");
                _loginScreen.TakePrintScreenImageFormatGif(@"c:\Screenshot\DeveExibirUmaMensagemErroQuandoUsuarioSenhaInvalido\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Gif");
                _loginScreen.TakePrintScreenImageFormatTiff(@"c:\Screenshot\DeveExibirUmaMensagemErroQuandoUsuarioSenhaInvalido\", $"{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.Tiff");
            }
            catch (System.Exception ex)
            {
                //TODO: Tratamento de erro
                throw ex;
            }
            finally
            {
                _loginScreen.CloseScreen();
            }

            Assert.True(!string.IsNullOrEmpty(response));
            Assert.Equal(response, expected);
        }
    }
}
