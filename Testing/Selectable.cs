using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace Testing
{
    partial class ToolsQa
    {
        public void Selectable()
        {
            url = "https://demoqa.com/selectable";
            IWebDriver driver = Open_Url();

            IWebElement List = driver.FindElement(By.XPath("//nav/a[@id='demo-tab-list']"));
            List_Select(List, driver);

            IWebElement grid = driver.FindElement(By.XPath("//nav/a[@id='demo-tab-grid']"));
            Grid_Select(grid, driver);

            close_quit();
            Console.ReadLine();
        }

        public Actions actions(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            return action;
        }

        private void List_Select(IWebElement list, IWebDriver driver)
        {

            // list.Click();
            actions(driver).MoveToElement(list).Click().Perform();
            IReadOnlyCollection<IWebElement> l = driver.FindElements(By.XPath("//*[@id='demo-tabpane-list']/ul/li"));
            int l_count = l.Count(), i = 0;
            string p1 = "//*[@id='demo-tabpane-list']/ul/li[text()='";
            string p2 = "']";
            IWebElement T;
            jex = (IJavaScriptExecutor)driver;
            foreach (IWebElement ele in l)
            {
                T = driver.FindElement(By.XPath(p1 + ele.Text + p2));
                actions(driver).MoveToElement(T).Click().Perform();

                jex.ExecuteScript("window.scrollBy(0,50)");
                i++;
                if (i > l_count)
                    break;
            }

        }

        private void Grid_Select(IWebElement grid, IWebDriver driver)
        {
            // grid.Click();

            actions(driver).MoveToElement(grid).Click().Perform();
            IReadOnlyCollection<IWebElement> g = driver.FindElements(By.XPath("//*[@id='gridContainer']/div"));
            IReadOnlyCollection<IWebElement> g_id;
            int g_count = g.Count();

            string p1 = "//*[@id='gridContainer']/div[@id='";
            string p2 = "']";
            string p3 = "/li[";
            string p4 = "]";
            string id; int i;

            try
            {

                // IWebElement ele1;
                foreach (IWebElement ele in g)
                {
                    i = 1;
                    // Console.WriteLine("Hi2");
                    id = ele.GetAttribute("id");
                    g_id = driver.FindElements(By.XPath(p1 + id + p2));


                    foreach (IWebElement ele1 in g_id)
                    {

                        //Console.WriteLine(ele1.Text);
                        //ele1.Text.Split().ToArray();

                        //Console.WriteLine(ele1.Text.Split().ToArray().Count().ToString());
                        while (i <= 3)
                        {

                            IWebElement g_ss = driver.FindElement(By.XPath(p1 + id + p2 + p3 + i + p4));
                            Console.WriteLine(p1 + id + p2 + p3 + i + p4);
                            actions(driver).MoveToElement(g_ss).Click().Perform();
                            i++;

                        }

                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}



//foreach (IWebElement ele2 in g_s)
//{
//    Console.WriteLine("Hi4");

//    Console.WriteLine("Hi6");
//    Thread.Sleep(1000);
//}




