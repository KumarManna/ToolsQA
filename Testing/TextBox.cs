using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    partial class ToolsQa
    {
        public void TestBox_Test()
        {

            string fname = "Abhijit", lname = "Manna", email = "abc_def@gmail.com", padr = "Hooghly";
            string cadr = "Kolkata";
            IWebDriver driver = new FirefoxDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            #region Textbox
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//input[@id='userName']")).SendKeys(fname + lname);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys(email);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//textarea[@id='currentAddress']")).SendKeys(cadr);
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//textarea[@id='permanentAddress']")).SendKeys(padr);
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,500)");
            driver.FindElement(By.XPath("//button[@id='submit']")).Click();
            Thread.Sleep(2000);
            #endregion
            driver.Close();
            driver.Quit();
            
        }
    }
}
