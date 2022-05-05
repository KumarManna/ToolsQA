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
        public void LinkTest()
        {
            IWebDriver driver = new FirefoxDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string url= "https://demoqa.com/links";
            string def_handle;

            driver.Navigate().GoToUrl(url);
            def_handle = driver.CurrentWindowHandle;
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//div/p/a[@id='simpleLink']")).Click();
            Thread.Sleep(2000);
            //cur_url = driver.Url;
            //cur_handle = driver.CurrentWindowHandle;


            Thread.Sleep(2000);
            driver.SwitchTo().Window(def_handle);
            //if (url != cur_url)
            //{
            //    driver.Navigate().Back();
            //    Thread.Sleep(5000);
            //}

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div/p/a[@id='dynamicLink']")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Window(def_handle);
            Thread.Sleep(2000);

            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//div/p/a[@id='created']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//div/p/a[@id='no-content']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//div/p/a[@id='moved']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,100)");
            driver.FindElement(By.XPath("//div/p/a[@id='bad-request']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,150)");
            driver.FindElement(By.XPath("//div/p/a[@id='unauthorized']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,200)");
            driver.FindElement(By.XPath("//div/p/a[@id='forbidden']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//div/p/a[@id='invalid-url']")).Click();
            Thread.Sleep(2000);
         
    
            driver.Close();
            driver.Quit();
            ////Console.WriteLine(cur_url);
            //Console.ReadKey();

        }
    }
}
