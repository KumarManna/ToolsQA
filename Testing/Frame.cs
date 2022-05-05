using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void Frame()
        {
            string frame1txt,frame2txt;
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor jex = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            driver.Manage().Window.Maximize();
            string p = driver.CurrentWindowHandle;
            Thread.Sleep(1000);
            IReadOnlyCollection<IWebElement> frames = driver.FindElements(By.TagName("iframe"));
            Console.WriteLine(frames.Count);
            try
            {
                IWebElement frame1 = driver.FindElement(By.XPath("//div/iframe[contains(@src,'/sample') and contains(@id,'frame1')]"));
                driver.SwitchTo().Frame(frame1);
                IWebElement frame1text = driver.FindElement(By.Id("sampleHeading"));
                // driver.SwitchTo().Frame(frame1text);
                frame1txt = frame1text.Text;
                Console.WriteLine(frame1txt);
                Thread.Sleep(2000);
                driver.SwitchTo().Window(p);
                jex.ExecuteScript("window.scrollBy(0,500)");
                IWebElement frame2 = driver.FindElement(By.XPath("//div/iframe[contains(@src,'/sample') and contains(@id,'frame2')]"));
                driver.SwitchTo().Frame(frame2);
                IWebElement frame2text = driver.FindElement(By.Id("sampleHeading"));
                frame2txt=frame2text.Text;
                Console.WriteLine(frame2txt);
                IJavaScriptExecutor jex2 = (IJavaScriptExecutor)driver;
                jex2.ExecuteScript("window.scrollBy(0,10)");
                Thread.Sleep(2000);
                jex2.ExecuteScript("window.scrollBy(5,0)");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                
            }
            finally
            {
                driver.Close();
                driver.Quit();
                Console.ReadKey();
            }
        }
    }
}
