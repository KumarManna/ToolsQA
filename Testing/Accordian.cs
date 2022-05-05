using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Testing
{
    partial class ToolsQa
    {
        public void Accordian()
        {
            url = "https://demoqa.com/accordian";
            IWebDriver driver = Open_Url();

            driver.FindElement(By.Id("section1Heading")).Click();
            driver.FindElement(By.Id("section2Heading")).Click();
            driver.FindElement(By.Id("section3Heading")).Click();
            close_quit();
            Console.ReadKey();
        }
    }
}

