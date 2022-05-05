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
        public void Upload_Download_Test()
        {
            IWebDriver driver = new FirefoxDriver();
            IWebElement upload;
           // IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string url = "https://demoqa.com/upload-download";
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div/div/a[@id='downloadButton']")).Click();
           // driver.FindElement(By.XPath("//div/div/a[@id='sampleFile.jpeg']")).Click();
            //Thread.Sleep(2000);
            upload=driver.FindElement(By.XPath("//*[@id='uploadFile']"));
            upload.SendKeys("C:\\Users\\abhij\\Downloads\\sampleFile.jpeg");
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }
    }
}
