using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Testing
{
    partial class ToolsQa
    {
        private string url { get; set; }
        WebDriverWait wait;
        private readonly IWebDriver driver = new ChromeDriver();
      // private readonly  IJavaScriptExecutor jex;
      //  Actions actions;
        private IWebDriver Open_Url()
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
               
                driver.Manage().Window.Maximize();
                
                return driver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        private void scroll()
        {
            jex = (IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,100)");
        }
       
        private bool close_quit()
        {
            try
            {
                driver.Close();
                driver.Quit();
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
