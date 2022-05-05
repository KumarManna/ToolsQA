using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Testing2
{
    public class Browser
    {
        protected internal string url { get; set; }
        protected internal WebDriverWait wait;
        protected readonly IWebDriver driver = new ChromeDriver();

        //  Actions actions;
        protected internal IWebDriver Open_Url()
        {
            try
            {
               this. driver.Navigate().GoToUrl(url);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

                this.driver.Manage().Window.Maximize();

                return this.driver;
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
                return null;
            }
           
        }

        protected internal void scroll()
        {
            IJavaScriptExecutor jex = (IJavaScriptExecutor)this.driver;
            jex.ExecuteScript("window.scrollBy(0,100)");
        }

        protected internal Actions Action(IWebDriver driver)
        {
            Actions ac = new Actions(driver);
            return ac;
        }

        protected internal void Mouse_Hover(IWebDriver driver, IWebElement ele)
        {
            Action(driver).MoveToElement(ele).Build().Perform();
            Thread.Sleep(100);
        }
        protected internal void Mouse_Action(IWebDriver driver,IWebElement ele)
        {
            Action(driver).MoveToElement(ele).Click().Build().Perform();
            Thread.Sleep(100);
        }

        protected internal void Mouse_Action(IWebDriver driver, IWebElement ele,string k)
        {
            Action(driver).MoveToElement(ele).Click().SendKeys(k).Build().Perform();
            Thread.Sleep(100);
        }

        protected internal void Click_SendKeys(IWebDriver driver, IWebElement ele, string k)
        {
            Action(driver).MoveToElement(ele).Click().Build().Perform();
            Action(driver).MoveToElement(ele).Click().SendKeys(k).Build().Perform();
            Thread.Sleep(100);
        }

        protected internal void Cursor_Move(IWebDriver driver, IWebElement ele)
        {
            Action(driver).MoveToElement(ele).Build().Perform();
            Thread.Sleep(100);
        }

        protected internal bool close_quit()
        {
            try
            {
               this. driver.Close();
               this. driver.Quit();
               return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
