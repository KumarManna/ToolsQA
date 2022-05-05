
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
        public void MenuHover()
        {
            url = "https://demoqa.com/menu#";
            IWebDriver driver = Open_Url();
            Actions ac1 = new Actions(driver);
            Actions ac2 = new Actions(driver);
            Actions asc2=new Actions(driver);
            Actions asc3=new Actions(driver);
            Actions asc4 = new Actions(driver);
            Actions asc5 = new Actions(driver);
            Actions asc6 = new Actions(driver);
            Actions ac3=new Actions(driver);
            jex = (IJavaScriptExecutor)driver;

            IWebElement c1= driver.FindElement(By.XPath("//ul[@id='nav']/li[1]"));
            ac1.MoveToElement(c1).Perform();
            ////Thread.Sleep(1000); 
            
            IWebElement c2 = driver.FindElement(By.XPath("//ul[@id='nav']/li[2]"));
            ac2.MoveToElement(c2).Perform();
            Thread.Sleep(1000);

            jex.ExecuteScript("window.scrollBy(0,100)");
           
            IWebElement sc2=c2.FindElement(By.XPath("//following-sibling::ul/li[1]/a[text()='Sub Item']"));
            asc2.MoveToElement(sc2).Perform();
          
            // jex.ExecuteScript("window.scrollBy(0,200)");
            
            IWebElement sc3 = c2.FindElement(By.XPath("//following-sibling::ul/li[2]/a[text()='Sub Item']"));
            asc3.MoveToElement(sc3).Perform();
      

            IWebElement sc4 = c2.FindElement(By.XPath("//following::ul/li[3]/a[text()='SUB SUB LIST »']"));
            //driver.SwitchTo().ActiveElement();
            asc4.MoveToElement(sc4).Perform();
            //Thread.Sleep(1000);

            

            IWebElement sc5 = sc4.FindElement(By.XPath("//following-sibling::ul/li[1]/a[text()='Sub Sub Item 1']"));
            asc5.MoveToElement(sc5).Perform();
            //Thread.Sleep(1000);

            IWebElement sc6 = c2.FindElement(By.XPath("//following-sibling::ul/li[2]/a[text()='Sub Sub Item 2']"));
            asc6.MoveToElement(sc6).Perform();
            //Thread.Sleep(1000);

            IWebElement c3 = driver.FindElement(By.XPath("//ul[@id='nav']/li[3]/a"));
            asc3.MoveToElement(c3).Perform();
            Thread.Sleep(1000);
            close_quit();
        }
    }
}
