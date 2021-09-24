using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestsCSharpWithSelenium.Utils;

namespace TestsCSharpWithSelenium.Screens
{
    public class BaseScreen
    {
        protected readonly IConfiguration _configuration;
        protected readonly Browser _browser;
        protected IWebDriver _webDriver;

        public BaseScreen(IConfiguration configuration, Browser browser)
        {
            _configuration = configuration;
            _browser = browser;

            _webDriver = WebDriverFactory.CreateWebDriver(browser, configuration.GetSection("Selenium:Drivers:Path").Value, false);
        }

        public void LoadScreen(string url)
        {
            _webDriver.LoadPage(TimeSpan.FromSeconds(15), url);
            _webDriver.Manage().Window.Maximize();
        }

        //Fecha a tela para que o navegador não consuma muita memória
        public void CloseScreen()
        {
            _webDriver.Quit();
            _webDriver = null;
        }

        public void WaitByHtml(TimeSpan secondsToWait, By by)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_webDriver, secondsToWait);
            webDriverWait.Until(x => !string.IsNullOrEmpty(x.FindElement(by).GetAttribute("innerHTML")));
        }

        public void WaitByValue(TimeSpan secondsToWait, By by)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_webDriver, secondsToWait);
            webDriverWait.Until(x => !string.IsNullOrEmpty(x.FindElement(by).GetAttribute("value")));
        }
    }
}
