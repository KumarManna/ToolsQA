using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Testing
{
    partial class ToolsQa
    {
        public void Click_Test()
        {
            IWebDriver driver = new FirefoxDriver();
            Actions action = new Actions(driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement rc, dc;

            driver.Navigate().GoToUrl("https://demoqa.com/buttons");
            Thread.Sleep(1000);
            dc=driver.FindElement(By.XPath("//div/button[@id='doubleClickBtn']"));
            Thread.Sleep(1000);
            action.DoubleClick(dc).Perform(); //double_click
            Thread.Sleep(3000);
            js.ExecuteScript("window.scrollBy(0,200)");
            rc = driver.FindElement(By.XPath("//div/button[@id='rightClickBtn']"));
            action.ContextClick(rc).Perform(); //right_click
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div/button[text()='Click Me']")).Click();
            Thread.Sleep(4000);

            driver.Close();
            driver.Quit();
        }
    }
}
