using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Testing
{
    partial class ToolsQa
    {
        public void Slider()
        {
          
            url = "https://demoqa.com/slider";
            IWebDriver driver= Open_Url();
           // WebDriverWait wait= new WebDriverWait(driver,TimeSpan.FromSeconds(60));

           IWebElement slide = driver.FindElement(By.XPath("//input[@class='range-slider range-slider--primary']"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'range-slider range-slider--primary']"))).Click();
           // Actions action = new Actions(driver);
           // Thread.Sleep(1000);
           // jex = (IJavaScriptExecutor)driver;
           // // jex.ExecuteScript("window.scrollBy(0,100)");
           // //// wait.Until(ExpectedConditions.ElementExists)
           wait.Until(ExpectedConditions.ElementToBeClickable(slide));
            //action.MoveToElement(slide).ClickAndHold().MoveByOffset(768, 253).Release();
            for (int i = 1; i <= 100; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class = 'range-slider range-slider--primary']"))).SendKeys(Keys.ArrowRight);
            }
            Thread.Sleep(10000);
            close_quit();
        }
    }
}
