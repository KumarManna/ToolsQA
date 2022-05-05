using System;
using OpenQA.Selenium;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using System.Threading;

namespace Testing
{
    partial class ToolsQa
    {
        public void Tab()
        {
            StringBuilder sb = new StringBuilder();
            url = "https://demoqa.com/tabs";
            IWebDriver driver = Open_Url();
            //string d;
            // string path1="//div/nav/a[(contains,@id,";
            //// sb.Append(path1);
            // string path2 = ")]";
            // IWebElement w = driver.FindElement(By.XPath(""));
            //IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));
            //foreach(IWebElement element in elements)
            //{
            //     id=element.GetAttribute("id");
            //    driver.FindElement(By.XPath("//div/nav/a[@contains," + id + "]"));
            //}
            IWebElement w = driver.FindElement(By.XPath("//div/nav/a[contains(@id,'demo-tab-what')]"));
            w.Click();
            Thread.Sleep(1000);
            IWebElement o = driver.FindElement(By.XPath("//div/nav/a[contains(@id,'demo-tab-origin')]"));
            o.Click();
            Thread.Sleep(1000);
            IWebElement u = driver.FindElement(By.XPath("//div/nav/a[contains(@id,'demo-tab-use')]"));
            u.Click();
            Thread.Sleep(1000);
            IWebElement m = driver.FindElement(By.XPath("//div/nav/a[contains(@id,'demo-tab-more')]"));
            string d = m.Text;
            try
            {
                m.Click();
            }

            catch (Exception)
            {
                Console.WriteLine(d + " Disabled");
            }
            Thread.Sleep(1000);
            close_quit();
            //Console.ReadKey();
        }
    }
}
