using OpenQA.Selenium;
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
        public void Modal()
        {
            url = "https://demoqa.com/modal-dialogs";
            IWebDriver driver = Open_Url();
            IWebElement sm = driver.FindElement(By.XPath("//div/button[contains(@id,'showSmallModal') and contains(@type,'button')]"));
            sm.Click();
            Thread.Sleep(1000);
            IWebElement csm = sm.FindElement(By.XPath("//following::div//button[contains(@id,'closeSmallModal') and contains(@type,'button')]"));
            csm.Click();
            Thread.Sleep(1000);
            IWebElement lm = driver.FindElement(By.XPath("//div/button[contains(@id,'showLargeModal') and contains(@type,'button')]"));  
            lm.Click();
            Thread.Sleep(1000);
            IWebElement clm = lm.FindElement(By.XPath("//following::div//button[contains(@id,'closeLargeModal') and contains(@type,'button')]"));
            clm.Click();
            Thread.Sleep(1000);
            close_quit();
        }
    }
}
