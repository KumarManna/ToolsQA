using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ToolsQA_Partial
{
    internal class All_Links
    {
        public static void Links()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.Manage().Window.Maximize();
            IReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("a"));
            foreach (IWebElement link in links)
            {
                Console.WriteLine(link.GetAttribute("href"));
            }
           // Console.WriteLine(links.Count);
            driver.Close();
            driver.Quit();
            Console.WriteLine(links.Count);
          
            Console.ReadKey();
        }

        public static void Screen_Shot()
        {

        }

        static void Main()
        {
           All_Links.Links();
        }
        
    }
}
