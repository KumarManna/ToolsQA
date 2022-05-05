using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Testing
{
    partial class ToolsQa
    {
        public void ToolTips()
        {
            

            url = "https://demoqa.com/tool-tips";
            IWebDriver driver = Open_Url();
            jex = (IJavaScriptExecutor)driver;

            Actions a=new Actions(driver);
            Actions a1 = new Actions(driver);
            Actions a2 = new Actions(driver);
            Actions a3= new Actions(driver);
           

            IWebElement f = driver.FindElement(By.XPath("//button[@id='toolTipButton']"));
            a.MoveToElement(f).Perform();
            Thread.Sleep(1000);
            
            jex.ExecuteScript("window.scrollBy(0,100)");
            IWebElement txtfield=driver.FindElement(By.XPath("//input[@id='toolTipTextField']"));
            a1.MoveToElement(txtfield).Perform();
            Thread.Sleep(1000);
            a1.MoveToElement(txtfield).Click().SendKeys("Hi").Perform();
            Thread.Sleep(1000);

            jex.ExecuteScript("window.scrollBy(0,100)");


            IWebElement href1=driver.FindElement(By.XPath("//div[@id='texToolTopContainer']/a[1]")); 
            a2.MoveToElement(href1).Perform();
            Thread.Sleep(1000);
            IWebElement href2 =driver.FindElement(By.XPath("//div[@id='texToolTopContainer']/a[2]"));
            a3.MoveToElement(href2).Perform();
            Thread.Sleep(1000);
           // IWebElement t = driver.FindElement(By.XPath("//button[@id='']"));
            close_quit();
        }
    }
}
