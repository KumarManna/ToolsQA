using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Testing
{
    partial class ToolsQa
    {
        public void Dynamic_Properties_Test()
        {
            IWebDriver driver = new FirefoxDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string url = "https://demoqa.com/dynamic-properties";

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//div/button[text()='Will enable 5 seconds']")).Click();
            Thread.Sleep(5000);

            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//*[text()='Color Change']")).Click();

            js.ExecuteScript("window.scrollBy(0,100)");
            driver.FindElement(By.XPath("//*[@id='visibleAfter']")).Click();


            Thread.Sleep(7000);
            driver.Close();
            driver.Quit();
        }
    }
}
