using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    partial class ToolsQa
    {
        public void NestedFrame()
        {
            //string parentTxt, childTxt;
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            try
            {
                IWebElement parentFrame = driver.FindElement(By.XPath("//div/iframe[contains(@src,'/sampleiframe') and contains(@id,'frame1')]"));
                driver.SwitchTo().Frame(parentFrame);
                IWebElement pTxt = driver.FindElement(By.TagName("body"));
                Console.WriteLine(pTxt.Text);
                Thread.Sleep(1000);
                driver.SwitchTo().DefaultContent();
                IWebElement childFrame = driver.FindElement(By.TagName("p"));
                driver.SwitchTo().Frame(childFrame);
                Console.WriteLine(childFrame.Text);
                Thread.Sleep(1000);
                driver.SwitchTo().DefaultContent();


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                driver.Close();
                driver.Quit();
                Console.ReadKey();
            }
        }
    }
}
