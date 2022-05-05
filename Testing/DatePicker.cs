using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Testing
{
    partial class ToolsQa
    {
        private void Select_Date(IWebDriver driver)
        {
            IJavaScriptExecutor jex=(IJavaScriptExecutor)driver;    
            string d = "28", m = "March",y="2030";
           // DateTime dateTime = DateTime.Parse();
            try
            {
                driver.FindElement(By.XPath("//div/input[contains(@id,'datePickerMonthYearInput')]")).Click();
                jex.ExecuteScript("window.scrollBy(0,200)");

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
                        //Thread.Sleep(5000);
                    }
                    
                }
                
                driver.FindElement(By.XPath("//select[contains(@class,'react-datepicker__month-select')]")).Click();
                Console.WriteLine("Month");
                foreach (IWebElement element in Month)
                {
                    if (element.Text == m)
                    {
                        element.Click();
                    }
                }
                
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
        private void Date_and_Time(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div/input[@id='dateAndTimePickerInput']")).Click();

            IReadOnlyCollection<IWebElement> year = driver.FindElements(By.XPath("//div[contains(@class,'react-datepicker__year-option')]"));
            IReadOnlyCollection<IWebElement> month = driver.FindElements(By.XPath("//div[contains(@class,'react-datepicker__month-dropdown')]"));

            foreach(IWebElement element in year)
            {
                Console.WriteLine(element.Text);
            }
            foreach(IWebElement element in month)
            {
                Console.WriteLine(element.Text);
            }
            //driver.FindElement(By.XPath("//span[@class='react-datepicker__year-read-view--down-arrow']")).Click();
            //driver.FindElement(By.XPath("//span[@class='react-datepicker__month-read-view']")).Click();

        }
        public void Date_Picker()
        {
            url = "https://demoqa.com/date-picker";
            IWebDriver driver = Open_Url();
            //Select_Date(driver);
            Date_and_Time(driver);
            Thread.Sleep(5000);
            driver.SwitchTo().DefaultContent();
            close_quit();
            Console.ReadKey();
        }
    }
}
