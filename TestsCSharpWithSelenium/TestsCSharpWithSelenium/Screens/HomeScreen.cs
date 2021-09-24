using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using TestsCSharpWithSelenium.Utils;

namespace TestsCSharpWithSelenium.Screens
{
    public class HomeScreen : BaseScreen
    {
        public HomeScreen(IConfiguration configuration, Browser browser) : base(configuration, browser)
        {
        }

        public string GetServices()
        {
            WaitByHtml(TimeSpan.FromSeconds(15), By.Id("servicos"));
            string response = _webDriver.GetHtml(By.Id("servicos"));
            return response;
        }
    }
}
