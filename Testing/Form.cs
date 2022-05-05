using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    partial class ToolsQa
    {
        static readonly string fname = "Abhijit", lname = "Manna", address = "Hooghly", email = "abc_xyz@gmail.com", mob = "123456789";

        private static void Name(IWebDriver driver)
        {
            //Access Method
            IWebElement first_name = driver.FindElement(By.XPath("//div/input[contains(@id,'firstName')]"));
            first_name.SendKeys(fname);
            Thread.Sleep(1000);
            IWebElement last_name = first_name.FindElement(By.XPath("//following::div//input[contains(@id,'lastName')]"));
            last_name.SendKeys(lname);
            Thread.Sleep(1000);
        }

        private static void Email(IWebDriver driver)
        {
            IWebElement mail = driver.FindElement(By.XPath("//div/input[contains(@type,'text') and contains(@id,'userEmail')]"));
            mail.SendKeys(email);
            Thread.Sleep(1000);

        }

        private void Gender(IWebDriver driver)
        {
            IWebElement male = driver.FindElement(By.XPath("//div[@class='custom-control custom-radio custom-control-inline']/input[@id='gender-radio-1']"));
            actions(driver).MoveToElement(male).Click().Build().Perform();
            IWebElement female = driver.FindElement(By.XPath("//div[@class='custom-control custom-radio custom-control-inline']/input[@id='gender-radio-2']"));
            actions(driver).MoveToElement(female).Click().Build().Perform();
            IWebElement other = driver.FindElement(By.XPath("//div[@class='custom-control custom-radio custom-control-inline']/input[@id='gender-radio-3']"));
            actions(driver).MoveToElement(other).Click().Build().Perform();
            Thread.Sleep(2000);
        }

        private void Mob(IWebDriver driver)
        {
            
            IWebElement m_form = driver.FindElement(By.XPath("//*[@id='userNumber']"));
            m_form.SendKeys(mob);
            Thread.Sleep(1000);
        }

        private void Date_Pick(IWebDriver driver)
        {
            jex=(IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,100)");



            string d = "28", m = "March", y = "2030";
          //  DateTime dateTime = DateTime.Parse();
            try
            {
                IWebElement dob = driver.FindElement(By.XPath("//*[@id='dateOfBirthInput']"));
                actions(driver).MoveToElement(dob).Click().Build().Perform();

                IReadOnlyCollection<IWebElement> Year = driver.FindElements(By.XPath("(//select[contains(@class,'react-datepicker__year-select')])//option"));
                IReadOnlyCollection<IWebElement> Month = driver.FindElements(By.XPath("//select[contains(@class,'react-datepicker__month-select')]//option"));
                IReadOnlyCollection<IWebElement> Day = driver.FindElements(By.XPath("//select[starts-with(@class,'react-datepicker__day')]"));
                Console.WriteLine("Year");
                driver.FindElement(By.XPath("//select[contains(@class,'react-datepicker__year-select')]")).Click();

                foreach (IWebElement element in Year)
                {
                    if (element.Text == y)
                    {
                        element.Click();
                    }

                }

                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//select[contains(@class,'react-datepicker__month-select')]")).Click();
                Console.WriteLine("Month");
                foreach (IWebElement element in Month)
                {
                    if (element.Text == m)
                    {
                        element.Click();
                    }
                }

                Thread.Sleep(1000);

                Console.WriteLine("Day");
                foreach (IWebElement element in Day)
                {
                    if (element.Text == d)
                    {
                        element.Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void Hobbies(IWebDriver driver)
        {
            scroll();

            IWebElement h = driver.FindElement(By.XPath("//*[@id='hobbiesWrapper']"));
            actions(driver).MoveToElement(h).Click().Build().Perform();
            Thread.Sleep(100);

            scroll();

            IWebElement h1 = h.FindElement(By.XPath("//following::input[@id='hobbies-checkbox-1']"));
            actions(driver).MoveToElement(h1).Click().Build().Perform();
            Thread.Sleep(100);

            scroll();

            IWebElement h2 = h.FindElement(By.XPath("//following::div/input[@id='hobbies-checkbox-2']"));
            actions(driver).MoveToElement(h2).Click().Build().Perform();
            Thread.Sleep(100);

            scroll();

            IWebElement h3 = h.FindElement(By.XPath("//following::div/input[@id='hobbies-checkbox-3']"));
            actions(driver).MoveToElement(h3).Click().Build().Perform();
            Thread.Sleep(100);

            scroll();
        }

        private void upload_pic(IWebDriver driver)
        {
            jex = (IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,200)");
            IWebElement up = driver.FindElement(By.XPath("//*[@id='uploadPicture']"));
            up.SendKeys("C:\\Users\\abhij\\Downloads");
            Thread.Sleep(1000);

        }
        public void Form()
        {

            url = "https://demoqa.com/automation-practice-form";
            IWebDriver driver = Open_Url();

            // Name(driver);
            //Email(driver);
            //Gender(driver);
            //Mob(driver);
            //Date_Pick(driver);
            //Hobbies(driver);
            //scroll();
            upload_pic(driver);
            scroll();
            close_quit();
            Console.ReadKey();
        }
    }
}

