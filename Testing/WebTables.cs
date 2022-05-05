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
       public void Web_Tables_Test()
        {
            string fname = "Abhijit Kumar", lname = "Manna", email = "abc_def12@gmail.com", age = "20";
            string salary = "1000000000", dept = "SDE";
            //IWebElement del;
            IWebDriver driver = new FirefoxDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Navigate().GoToUrl("https://demoqa.com/webtables");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("addNewRecordButton")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div/input[@placeholder='First Name']")).SendKeys(fname);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div//input[@placeholder='Last Name']")).SendKeys(lname);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div/input[@placeholder='name@example.com']")).SendKeys(email);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("age")).SendKeys(age);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("salary")).SendKeys(salary);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div/input[@placeholder='Department']")).SendKeys(dept);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div/button[@id='submit']")).Click();
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,50)");
            driver.FindElement(By.XPath("//div/input[@placeholder='Type to search']")).SendKeys(fname+" "+lname);
            Thread.Sleep(1000);
            //Console.WriteLine(driver.)
            driver.Close();
            driver.Quit();
        }
    }
}
