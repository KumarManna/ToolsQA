using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing2
{
    internal class Click_Hover:Browser
    {
        protected internal void Form_Fill(IWebDriver driver, By by)
        {
            /* 
             * The function is intendent to click and element after it is visible
             * or wait 25 seconds maximum to click
             */
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement element1 = driver.FindElement(by);
            Cursor_Move(driver, element1);
            Mouse_Action(driver, element1);
        }
        protected internal void Form_Fill(IWebDriver driver, By by, string info)
        {
            /*
             * The function is intendent to click and element after it is visible
             * or wait 25 seconds maximum to click and send values to element
             */
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement element = driver.FindElement(by);
            Mouse_Action(driver, element);
            Click_SendKeys(driver, element, info);
        }
        protected internal void drop_down_list(IWebDriver driver, By by, string k)
        {
            /* 
             * The function is intendent to check all text or attributes or tags
             * to check with user input
             */
            IReadOnlyCollection<IWebElement> list = driver.FindElements(by);
            foreach (IWebElement element in list)
            {
                if (k == element.Text)
                {
                    element.Click();
                }
            }
        }
    }
}
