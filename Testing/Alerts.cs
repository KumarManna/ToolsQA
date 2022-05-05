using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testing
{
    partial class ToolsQa
    {
        public void Alerts()
        {
            IJavaScriptExecutor jex;
            url = "https://demoqa.com/alerts";

            IWebDriver driver = Open_Url();
            jex=(IJavaScriptExecutor)driver;

            try
            {
                jex.ExecuteScript("window.scrollBy(0,200)");
                driver.FindElement(By.XPath("//div/button[contains(@id,'alertButton') and contains(@type,'button')]")).Click();
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(1000);
                Timer_Alert(driver);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/button[contains(@id,'confirmButton') and contains(@type,'button')]")).Click();
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(2000);
                IWebElement pb = driver.FindElement(By.XPath("//div/button[contains(@id,'promtButton') and contains(@type,'button')]"));
                pb.Click();
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().SendKeys("AbcDef");
                Thread.Sleep(3000); 
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Any alert exception {0}",ex);
                Console.ReadKey();
            }
            finally
            {
                close_quit();
            }

        }
        private void Timer_Alert(IWebDriver driver)
        {
            try
            {

                //driver.FindElement(By.XPath("//div/button[contains(@id,'timerAlertButton') and contains(@type,'button')]")).Click();
                //Thread.Sleep(5000);
                IWebElement alertButton =driver.FindElement(By.XPath("//div/button[contains(@id,'timerAlertButton') and contains(@type,'button')]"));
                alertButton.Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.AlertIsPresent());
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Timer Exception: "+ex);
               // Console.ReadKey();
            }
        }
    }
}
