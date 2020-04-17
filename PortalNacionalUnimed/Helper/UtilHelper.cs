using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace PortalNacionalUnimed.Helper
{
    public class UtilHelper : WebDriver
    {
        public void FechaNavegador()
        {
            driver.Close();
            driver.Dispose();
        }

        public void WaitElement(By by, int time)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }
}
