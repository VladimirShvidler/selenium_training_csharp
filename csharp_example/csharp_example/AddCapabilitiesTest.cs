using System;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace csharp_example
{
    [TestFixture]
    public class AddCapabilitiesTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Dismiss;
            driver = new InternetExplorerDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            


        }

        [Test]
        public void CapabilitiesTest ()
        {
            driver.Url = "http://meta.ua/";
            //IWebElement q = driver.FindElement(By.Name("q"));
            //driver.Navigate().Refresh();
            //q.SendKeys("webdriver");
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            driver.FindElement(By.Id("sb")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdriver - <META> - found 100 documents"));
            
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
