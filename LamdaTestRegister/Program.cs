using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaTestRegister
{
    class Program
    {
       readonly static string name = "Abhijit Manna", email = "xyz_abd@gmail.com", num = "1234567892", org = "None";
        private static void driver_close_quit(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
        }
        private static void Logical_Xpath(IWebDriver driver)
        {
            IWebElement name = driver.FindElement(By.XPath("//div/input[contains(@id,'name') and contains(@placeholder,'Full Name')]"));
            name.SendKeys(Program.name);
            Thread.Sleep(1000);
            //IWebElement email = driver.FindElement(By.XPath("//div/input[contains(@id,'email') or contains(@type,'email')]"));
            //email.SendKeys(Program.email);
            //Thread.Sleep(1000);
            //IWebElement password = driver.FindElement(By.XPath("//div/input[contains(@id,'userpassword') and contains(@name,'password')]"));
            //password.SendKeys("1234");
            //Thread.Sleep(1000);
            
            //IWebElement country_code = driver.FindElement(By.XPath("//div/select[contains(@id,'country_code')]"));
            //country_code.Click();
            //Thread.Sleep(1000);
            //driver.SwitchTo().ActiveElement();
            //IWebElement country_code_select = driver.FindElement(By.XPath("//div/select/options[contains(@value,'+91')]"));
            // country_code_select.Click();
            //Thread.Sleep(1000);
            //IWebElement phnum = driver.FindElement(By.XPath("//div/input[contains(@id,'phone') or contains(@placeholder,'Phone*')]"));
            //phnum.SendKeys(Program.num);
            //Thread.Sleep(1000);

            IWebElement orga = driver.FindElement(By.XPath("//div/input[contains(@id,'org_name') and contains(@name,'org_name')]"));
            orga.SendKeys(Program.org);
            Thread.Sleep(1000);

            IWebElement role = driver.FindElement(By.XPath("//div/select[contains(@id,'designation') or contains(@name,'designation')]"));
            role.Click();
            driver.SwitchTo().ActiveElement();
            IWebElement desig = driver.FindElement(By.XPath("(//div/select[contains(@id,'designation')]//option)[3]"));
            desig.Click();
            //driver.FindElement(By.XPath("(//select[@id='designation']//option)[5]"))
            Thread.Sleep(4000);
            //IWebElement check_box = driver.FindElement(By.XPath("//samp[contains(@class,'customcheckbox')]"));
            //check_box.Click();
            //Thread.Sleep(1000);
            //driver_close_quit(driver);
        }
        private static void chained_Xpath(IWebDriver driver)
        {
            //privacy policy
            IWebElement agree_label = driver.FindElement(By.XPath("//label[contains(@class,'i_agree_t')]"));
            IWebElement agree_check =agree_label.FindElement(By.XPath("//label//span//a[contains(@data-amplitude,'R_pp')]"));
            agree_check.Click();
            Thread.Sleep(2000);
            IReadOnlyCollection<string> curr_handle = driver.WindowHandles;
            foreach(string o in curr_handle)
            {
                Console.WriteLine(o);
            }
            // string privacy_page=driver.WindowHandles[]
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
        } 
        private static void Access_Method(IWebDriver driver)
        {
            //password 'following' phone num
            //password 'preceding' email

            IWebElement pass = driver.FindElement(By.XPath("//div/input[contains(@id,'userpassword') and contains(@name,'password')]"));
            pass.SendKeys("Abcd!234");
            Thread.Sleep(1000);

            IWebElement ph = pass.FindElement(By.XPath("//following::div//input[@id='phone']"));
            ph.SendKeys(Program.num);
            Thread.Sleep(1000);

            IWebElement mail = pass.FindElement(By.XPath("//preceding::div//input[contains(@id,'email') or contains(@type,'email')]"));
            mail.SendKeys(Program.email);
            Thread.Sleep(1000);
        }
        private static void Sibling(IWebDriver driver)
        {
            //preceding-sibling,following-sibling
            driver.FindElement(By.XPath("//div/select[contains(@id,'country_code') and contains(@name,'country_code')]")).Click();
            Thread.Sleep(500);

            IWebElement c_code_by_sibling = driver.FindElement(By.XPath("//div/select/option[contains(@data-countrycode,'IL')]"+"//following-sibling::option[1]"));
            c_code_by_sibling.Click();
            Thread.Sleep(2000);

            IWebElement India_code = driver.FindElement(By.XPath("//div//select/option[contains(@data-countrycode,'IL')]" + "//preceding-sibling::option[5]"));
            India_code.Click();
            Thread.Sleep(4000);
        }
        private static void git_sign_in(IWebDriver driver)
        {
            //child---google sign in->Github
            //IWebElement sign__in = driver.FindElement(By.XPath("//div/a[contains(@class,'googleSignInBtn')]"+"//span[contains(text(),'Github')]"));
            IWebElement sign__in=driver.FindElement(By.XPath("//a[contains(@class,'googleSignInBtn')]"+"//span[contains(text(),'Github')]"));
            /*    "//a[contains(@class,'googleSignInBtn')]" + "//span[contains(text(),'Github')]"   */
            sign__in.Click();
            Thread.Sleep(2000);
        }
        private static void child_to_parent(IWebDriver driver)
        {
            IWebElement password = driver.FindElement(By.XPath("//div/input[contains(@id,'email')]//parent::div//following-sibling::div//input[@type='password']"));
            password.SendKeys("123345ASDF0508!@#$($800");
            Thread.Sleep(2000);
        }
        static void Main(string[] args)
        {
            string url = "https://accounts.lambdatest.com/register/";
            //Program p = new Program();
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                Thread.Sleep(1000);
                //Logical_Xpath(driver);
                //Access_Method(driver);
                //chained_Xpath(driver);
                // Sibling(driver);
                //git_sign_in(driver);
                child_to_parent(driver);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                driver_close_quit(driver);
                Console.ReadKey();
            }
        }
    }
}
