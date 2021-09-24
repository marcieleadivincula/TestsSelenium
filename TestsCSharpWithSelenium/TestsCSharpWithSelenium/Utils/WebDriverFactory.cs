using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestsCSharpWithSelenium.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.Firefox:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    if (headless)
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    webDriver = new FirefoxDriver(pathDriver, firefoxOptions);
                    break;
                case Browser.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    webDriver = new ChromeDriver(pathDriver, chromeOptions);
                    break;
                case Browser.Edge:
                    EdgeOptions edgeOptions = new EdgeOptions();
                    if (headless)
                    {
                        //edgeOptions.AddArgument("--headless");
                    }
                    webDriver = new EdgeDriver(pathDriver, edgeOptions);
                    break;
                default:
                    break;
            }

            return webDriver;
        }
    }
}
