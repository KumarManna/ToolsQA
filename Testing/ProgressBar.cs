using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Testing
{
    partial class ToolsQa
    {

        public void Progress_Bar()
        {
            url = "https://demoqa.com/progress-bar";
            IWebDriver driver = Open_Url();
            jex = (IJavaScriptExecutor)driver;
            IWebElement btn_start = driver.FindElement(By.XPath("//div/button[@id='startStopButton']"));

            IWebElement btn_stop = btn_start.FindElement(By.XPath("//following::div/button[@id='startStopButton']"));


            IWebElement p_info = driver.FindElement(By.XPath("//div[contains(@class,'progress-bar bg-info')]"));

            try
            {
                while (!bar_info(p_info).Equals("100"))
                {
                    start_stop(btn_start, btn_stop, p_info);

                    Console.WriteLine(bar_info(p_info));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                close_quit();
            }

            // close_quit();
        }

        private string bar_info(IWebElement info)
        {
            return info.Text.ToString();
        }

        private void start_stop(IWebElement start, IWebElement stop, IWebElement p_info)
        {

            //j.ExecuteScript("window.scrollBy(0,50)");

            try
            {
                start.Click();
                Thread.Sleep(2000);
                stop.Click();
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine(p_info.Text);
                if (bar_info(p_info).Equals("100"))
                {
                    IWebElement btn_reset = stop.FindElement(By.XPath("//following::div/button[@id='resetButton']"));
                    btn_reset.Click();
                    Thread.Sleep(2000);
                }
                close_quit();
                //Console.WriteLine(ex);
            }
            //wait.Until(ExpectedConditions.ElementToBeClickable(start));
            //wait.Until(ExpectedConditions.ElementToBeClickable(stop));

        }
    }
}
