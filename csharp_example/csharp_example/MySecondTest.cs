using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace csharp_example
{
    [TestFixture]
    public class MySecondTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

    [SetUp]
        public void start()
        {
            try
            {
                driver = new ChromeDriver();
            }
            catch (DriverServiceNotFoundException ex)
            {
                MessageBox.Show(ex.Message,
                        "Critical Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
             
            }
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));        


        }
 

        [Test]
        public void SecondTest()
        {
            driver.Url = "http://localhost:8080/litecart/admin/";
            try
            {
                driver.FindElement(By.Name("username")).SendKeys("admin");
                driver.FindElement(By.Name("password")).SendKeys("admin");
                driver.FindElement(By.Name("login")).Click();
                wait.Until(ExpectedConditions.TitleIs("My Store"));
                driver.FindElement(By.CssSelector("i.fa.fa-chevron-circle-left")).Click();
                wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            }
            catch (NoSuchElementException ex)
            {
                MessageBox.Show(ex.Message,
                    "Critical Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            catch (StaleElementReferenceException ex)
            {
                MessageBox.Show(ex.Message,
                    "Critical Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            catch (WebDriverTimeoutException ex)
            {
                MessageBox.Show(ex.Message,
                    "Critical Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
            catch (ElementNotVisibleException ex)
            {
                MessageBox.Show(ex.Message,
                    "Critical Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }

           
            
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}