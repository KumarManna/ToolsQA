using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace Testing
{
    partial class ToolsQa
    {
        public void Resize()
        {
            url = "https://demoqa.com/resizable";
            IWebDriver driver = Open_Url();

            actions(driver).ClickAndHold(wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='constraint-area']//child::span")))).MoveByOffset(75,80).Release().Build().Perform();

            jex = (IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,200)");

            actions(driver).ClickAndHold(wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='box react-resizable']//child::span")))).MoveByOffset(90, 80).Release().Build().Perform();

            close_quit();
        }
    }
}
