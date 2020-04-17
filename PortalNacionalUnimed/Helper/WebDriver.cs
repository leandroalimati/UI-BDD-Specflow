using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace PortalNacionalUnimed.Helper
{
    public class WebDriver
    {
        public static IWebDriver driver;

        public void AbreUrl() => driver.Navigate().GoToUrl("https://www.unimed.coop.br/");

        private IWebDriver ObtemDriver() => ObtemDriver(TipoDriver.Chrome);

        public void Inicializar()
        {
            driver = ObtemDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
        }

        public enum TipoDriver
        {
            Chrome,
            ChromeHeadLess,
        }

        private IWebDriver ObtemDriver(TipoDriver tipoDriver)
        {
            IWebDriver driver;

            switch (tipoDriver)
            {
                case TipoDriver.ChromeHeadLess:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("headless");
                    var chromeDriverExePath2 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var driverService2 = ChromeDriverService.CreateDefaultService(chromeDriverExePath2);
                    driver = new ChromeDriver(chromeDriverExePath2, options);
                    options.AddArguments("--ignore-certificate-erros", "test-type", "incognito", "-disable-popup-blocking");
                    break;

                case TipoDriver.Chrome:
                    var chromeDriverExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var driverService = ChromeDriverService.CreateDefaultService(chromeDriverExePath);
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--ignore-certificate-erros", "test-type", "incognito", "-disable-popup-blocking");
                    driver = new ChromeDriver(driverService, chromeOptions);
                    break;

                default:
                    driver = new ChromeDriver();
                    break;
            }

            return driver;
        }
    }
}
