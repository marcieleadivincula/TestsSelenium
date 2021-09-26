using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using TestsCSharpWithSelenium.Utils;

namespace TestsCSharpWithSelenium.Screens
{
    public class LoginScreen : BaseScreen
    {
        public LoginScreen(IConfiguration configuration, Browser browser) : base(configuration, browser)
        {
        }

        //Método genêrico para setar login e senha
        public void SetText(string element, string value)
        {
            _webDriver.SetText(By.Id(element), value);
        }

        //Método para setar login
        public void SetLogin(string login)
        {
            //WaitByValue(TimeSpan.FromSeconds(15), By.Id("login"));
            _webDriver.SetText(By.Id("login"), login);
        }

        //Método para setar senha
        public void SetPassword(string password)
        {
            _webDriver.SetText(By.Id("senha"), password);
        }

        public void Submit()
        {
            _webDriver.Submit(By.Id("entrar"));
        }

        public string GetUserLogin()
        {
            WaitByHtml(TimeSpan.FromSeconds(15), By.ClassName("texto-branco"));
            string response = _webDriver.GetHtml(By.ClassName("texto-branco"));
            return response;
        }

        public string GetErrorMessage()
        {
            WaitByHtml(TimeSpan.FromSeconds(15), By.Id("mensagemDeErro"));
            string response = _webDriver.GetHtml(By.Id("mensagemDeErro")).Trim();
            return response;
        }
    }
}
