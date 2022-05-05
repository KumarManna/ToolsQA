using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace PHPtravels
{
    class Program
    {
        //string user_email = "user@phptravels.com";
        //string password = "demouser";
        string fname = "Abhijit", lname = "Manna", mail = "abc@xyz.com", num = "1234567891";
        private static void driver_close_quit(IWebDriver d)
        {
            d.Close();
            d.Quit();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string def_win_handle, def_url = "https://phptravels.com/", cs_login_url;
            try
            {
                driver.Navigate().GoToUrl(def_url);
                driver.Manage().Window.Maximize();
                def_win_handle = driver.CurrentWindowHandle;
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//nav/a[@href='https://phptravels.com/demo']")).Click();
                string demo_handle = driver.CurrentWindowHandle;
                driver.SwitchTo().Window(driver.CurrentWindowHandle); //to demo
                driver.Manage().Window.Maximize();
                Console.WriteLine("Current handle ={0}", driver.CurrentWindowHandle);
                Thread.Sleep(2000);

                #region login page
                driver.FindElement(By.XPath("//a[contains(@href,'login')]")).Click();
                Thread.Sleep(4000);
                // driver.FindElement(By.XPath("//nav/ul/li/a[@href='https://www.phptravels.net/hotels']")).Click();
                // driver.FindElement(By.XPath("//nav/ul/li/a/contains[@href,'hotels']")).Click();
                IReadOnlyCollection<string> curr_handle = driver.WindowHandles;
                string x = driver.WindowHandles[0];
                string y = driver.WindowHandles[1];
                foreach (string o in curr_handle)
                {
                    Console.WriteLine(o);
                }
                driver.SwitchTo().Window(y);
                Console.WriteLine("Current handle [log in handle] --- {0}", driver.CurrentWindowHandle);
                #endregion

                #region CurrencyChange

                driver.FindElement(By.XPath("//div/button[@id='currency']")).Click();
                driver.FindElement(By.XPath("//*[contains(@href,'https://www.phptravels.net/currency-INR')]")).Click();

                #endregion

                #region Hotel


                // driver.FindElement(By.XPath("//*[@href='https://www.phptravels.net/hotels']")).Click();
                // Thread.Sleep(2000);
                // string z = driver.CurrentWindowHandle;
                // Console.WriteLine(z);
                // driver.SwitchTo().Window(z);
                //driver.FindElement(By.XPath("//*[@type='search']")).Click();
                // // Console.WriteLine("Current handle ={0}", driver.CurrentWindowHandle);
                //// SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath("*[@id='fadein']/span/span/span[1]/input")));
                // ////*[@id="fadein"]/span/span/span[1]/input
                // //////html/body/span/span/span[1]/input
                // Thread.Sleep(2000);
                #endregion
                #region flight
                driver.FindElement(By.XPath("//*[@href='https://www.phptravels.net/flights']")).Click();
                string z = driver.CurrentWindowHandle;
                driver.SwitchTo().Window(z);
                driver.FindElement(By.XPath("//input[@id='round-trip']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id='one-way']")).Click();
                Thread.Sleep(1000);
                SelectElement flying_from = new SelectElement(driver.FindElement(By.XPath("//div/select[@id='flight_type']")));
                flying_from.SelectByText("First");
                driver.FindElement(By.XPath("//input[@id='autocomplete']")).SendKeys("Kolkata");
                driver.FindElement(By.XPath("//input[@id='autocomplete2']")).SendKeys("Delhi");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@id='departure']")).Clear();
                driver.FindElement(By.XPath("//input[@id='departure']")).SendKeys("21-04-2022");
                Thread.Sleep(1000);
                js.ExecuteScript("window.scrollBy(0,200)");
                driver.FindElement(By.XPath("//div/a[@data-toggle='dropdown']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/input[@id='fadults']")).Clear();
                driver.FindElement(By.XPath("//div/input[@id='fadults']")).SendKeys("2");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/input[@id='fchilds']")).SendKeys("0");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/input[@id='finfant']")).SendKeys("1");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/button[@id='flights-search']")).Click();
                Thread.Sleep(2000);
                #endregion

                #region visa
                driver.SwitchTo().Window(y);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//div/nav/ul/li/a[contains(@href,'visa')]")).Click();
                string a = driver.CurrentWindowHandle;
                driver.SwitchTo().Window(a);
                Thread.Sleep(2000);
                // driver.FindElement(By.XPath("//select[@id='from_country]")).Click();
                SelectElement fc = new SelectElement(driver.FindElement(By.XPath("//*[@id='from_country']")));
                fc.SelectByText("India");
                Thread.Sleep(2000);
                SelectElement tc = new SelectElement(driver.FindElement(By.XPath("//div/select[@id='to_country']")));
                tc.SelectByText("Japan");
                Thread.Sleep(2000);
                //driver.FindElement(By.XPath("//div[contains(@class,'datepicker dropdown-menu')]")).Clear();
                //driver.FindElement(By.XPath("//input/id[contains(@id,'date')]")).SendKeys("21-04-2022");
                driver.FindElement(By.XPath("//div/button[@id='submit']")).Click();
                Thread.Sleep(1000);
                driver.SwitchTo().Window(driver.CurrentWindowHandle);
                driver.FindElement(By.XPath("//div/input[contains(@name,'first_name')]")).SendKeys(p.fname);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/input[contains(@name,'last_name')]")).SendKeys(p.lname);
                Thread.Sleep(1000);
                js.ExecuteScript("window.scrollBy(0,200)");
                driver.FindElement(By.XPath("//div/input[contains(@name,'email')]")).SendKeys(p.mail);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/input[contains(@name,'phone')]")).SendKeys(p.num);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/textarea[contains(@name,'notes')]")).SendKeys("Need visa soon");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div/button[@id='submit']")).Click();
                Thread.Sleep(2000);
                driver.Close();
                #endregion
                Thread.Sleep(2000);
                driver.SwitchTo().Window(x);
                driver.Navigate().Back();
                driver.SwitchTo().Window(driver.CurrentWindowHandle);
                driver.Navigate().Back();
                Thread.Sleep(1000);
                driver.SwitchTo().Window(driver.CurrentWindowHandle);
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Program.driver_close_quit(driver);
            }
            Console.ReadKey();
        }
    }
}
