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
    internal class CheckBox
    {
        IWebDriver driver;
        IJavaScriptExecutor js;
        string url= "https://demoqa.com/checkbox";
        private bool HomeButton()
        {
            try
            {
                driver.FindElement(By.XPath("//button[@title='Toggle']")).Click();
                Thread.Sleep(2000);
                //driver.FindElement(By.XPath("//*[@title='Toggle']")).Click();
                //Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,50)");
                driver.FindElement(By.XPath("//span[text()='Desktop']")).Click();
                Thread.Sleep(1000);
                js.ExecuteScript("window.scrollBy(0,200)");
                driver.FindElement(By.XPath("//span[text()='Documents']")).Click();
                Thread.Sleep(1000);
                driver.Manage().Window.Maximize();
                Thread.Sleep(1000);
                js.ExecuteScript("window.scrollBy(0,500)");
                driver.FindElement(By.XPath("//span[text()='Downloads']")).Click();
                Thread.Sleep(1000);
                driver.SwitchTo().DefaultContent();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        private bool Expand()
        {
            try
            {
                driver.FindElement(By.XPath("//button[@aria-label='Expand all']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//span[text()='Notes']")).Click();
                Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,50)");
                driver.FindElement(By.XPath("//span[text()='Commands']")).Click();
                Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,150)");
                //driver.FindElement(By.XPath("//span[text()='WorkSpace']")).Click();
                //Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,50)");
                driver.FindElement(By.XPath("//span[text()='React']")).Click();
                Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,50)");
                driver.FindElement(By.XPath("//span[text()='Angular']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//span[text()='Veu']")).Click();
                Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,150)");
                driver.FindElement(By.XPath("//span[text()='Public']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//span[text()='Private']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//span[text()='Classified']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//span[text()='General']")).Click();
                Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,200)");
                driver.FindElement(By.XPath("//span[text()='Word File.doc']")).Click();
                Thread.Sleep(2000);
                js.ExecuteScript("window.scrollBy(0,50)");
                driver.FindElement(By.XPath("//span[text()='Excel File.doc']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//button[@aria-label='Collapse all']")).Click();
                Thread.Sleep(3000);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
       protected internal  static void main()
        {
            CheckBox cb = new CheckBox();
            cb.driver= new FirefoxDriver();
            cb.js = (IJavaScriptExecutor)cb.driver;

            cb.driver.Navigate().GoToUrl(cb.url);
            Thread.Sleep(1000);
            cb.driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
           
            
            bool home_run=cb.HomeButton();
            //cb.driver.SwitchTo().Window(cb.driver.CurrentWindowHandle);
            bool expand_run = cb.Expand();

            cb.driver.Close();
            cb.driver.Quit();
            Console.WriteLine("Home run={0} \n Expand run={1}",home_run,expand_run);
            Console.ReadLine();
        }
    }
}
