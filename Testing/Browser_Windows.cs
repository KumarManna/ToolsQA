using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace Testing
{
    partial class ToolsQa
    {
        private readonly string _url = "https://demoqa.com/browser-windows";
        IJavaScriptExecutor jex;
        public void Browser_Windows()
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl(_url);
                driver.Manage().Window.Maximize();
                Thread.Sleep(1000);
                string p = driver.CurrentWindowHandle;
                NewTab(driver);
                driver.SwitchTo().Window(p);
                Thread.Sleep(1000);
                New_Win(driver);
                driver.SwitchTo().Window(p);
                Thread.Sleep(1000);
                New_Win_Msg(driver);    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        private void NewTab(IWebDriver driver)
        {
            IWebElement nt = driver.FindElement(By.XPath("//div/button[contains(@id,'tabButton') and contains(@type,'button')]"));
            nt.Click();
            string c = driver.WindowHandles[1];
            driver.SwitchTo().Window(c);
            Thread.Sleep(2000);
            driver.Close();
        }
        private void New_Win(IWebDriver driver)
        {
            IWebElement nt = driver.FindElement(By.XPath("//div/button[contains(@id,'windowButton') and contains(@type,'button')]"));
            nt.Click();
            string c = driver.WindowHandles[1];
            driver.SwitchTo().Window(c);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.Close();

        }
        private void New_Win_Msg(IWebDriver driver)
        {
            jex = (IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,200)");
            IWebElement nwm = driver.FindElement(By.XPath("//div/button[contains(@id,'messageWindowButton') and contains(@type,'button')]"));
            nwm.Click();
            Thread.Sleep(3000);
            string c = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(c);
            driver.Manage().Window.FullScreen();
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }
    }
}
