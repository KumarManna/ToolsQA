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
        public void BrokenLink_Test()
        {

            IWebDriver driver = new FirefoxDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string url = "https://demoqa.com/broken";
            //string cur_url, def_handle, cur_handle;

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            // def_handle = driver.CurrentWindowHandle;

            js.ExecuteScript("window.scrollBy(0,200)");
            driver.FindElement(By.XPath("//div/a[text()='Click Here for Valid Link']")).Click();

            Thread.Sleep(2000);
            driver.Navigate().Back();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,290)");
            driver.FindElement(By.XPath("//div/a[text()='Click Here for Broken Link']")).Click();
            Thread.Sleep(2000);
            driver.Navigate().Back();
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }
    }
}
