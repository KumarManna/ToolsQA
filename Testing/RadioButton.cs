using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    partial class ToolsQa
    {
        public void Radio_Button_Test()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/radio-button");
            //Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
           
            driver.FindElement(By.XPath("//div/label[@for='yesRadio']")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//div/label[@for='impressiveRadio']")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//div/label[@for='noRadio']")).Click();
            Thread.Sleep(2000);

            driver.Close();
            driver.Quit();
        }
    }
}
