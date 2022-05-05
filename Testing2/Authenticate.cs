using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Testing2.Browser;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Testing2
{
    internal class Authenticate 
    {
        
        protected internal void Home_Page()
        {
            //Authenticate a=new Authenticate();
            Browser browser = new Browser();
            browser.url = "http://automationpractice.com/index.php";
            try
            {
                IWebDriver driver = browser.Open_Url();

                string def_handle = driver.CurrentWindowHandle;

                IWebElement sign_in = driver.FindElement(By.XPath("//div/a[@class='login' and @href='http://automationpractice.com/index.php?controller=my-account']"));

                browser.Action(driver).MoveToElement(sign_in).Click().Build().Perform();

                Thread.Sleep(100);

                Console.WriteLine(driver.CurrentWindowHandle);

                Form form = new Form();
                //form.SignUp_Form(driver, browser);
                //form.Sign_Out(driver, browser);
                //form.Sign_in(driver, browser);
                Order o=new Order();
                o.Choose(driver, browser, form);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                browser.close_quit();
            }
            Console.ReadKey();
        }
    }
}
