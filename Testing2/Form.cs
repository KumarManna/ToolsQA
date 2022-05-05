using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Testing2
{
    internal class Form : User_Interface
    {
        string fName { get; set; }
        string lName { get; set; }
        string dob_d { get; set; }
        string dob_m { get; set; }
        string dob_y { get; set; }
        string c_name { set; get; }
        string adr { set; get; }
        string city { set; get; }
        string state { set; get; }
        string pin_code { set; get; }
        string country { set; get; }
        string ph { set; get; }
        string Password { set; get; }
        string Email { set; get; }

        public void SignUp_Form(IWebDriver driver, Browser b)
        {
            //  driver.SwitchTo().Window(driver.CurrentWindowHandle);

            Console.WriteLine(driver.CurrentWindowHandle);

            this.Email = "Abo@hopefull.com";
            this.fName = "Pie";
            this.lName = "Chart";
            this.dob_d = "20";
            this.dob_m = "September";
            this.dob_y = "1999";
            this.adr = "M.G Street,Hello Lane,Imagination";
            this.country = "India";
            this.c_name = "Fun Company";
            this.city = "Imaginary";
            this.state = "Ohio";
            this.ph = "000000";
            this.pin_code = "00000";
            this.Password = "56@oi!AbghuIO";

            By email = By.XPath("//*[@id='email_create']");
            Form_Fill(driver, email, b, this.Email);

            Thread.Sleep(100);

            b.scroll();
            By sub = By.XPath("//*[@id='email_create']//following::button[@id='SubmitCreate']");
            Form_Fill(driver, sub, b);


            #region Male Select
            // //div[@id='uniform-id_gender1']
            b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@for='id_gender1']")));
            IWebElement mr = driver.FindElement(By.XPath("//div/label[@for='id_gender1']"));
            b.Cursor_Move(driver, mr);

            Thread.Sleep(1000);
            IWebElement c_mr = mr.FindElement(By.XPath("//following-sibling::div/span/input[@id='id_gender1']"));
            b.Mouse_Action(driver, c_mr);
            //b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//following-sibling::div/span/input[@id='id_gender1']")));
            #endregion

            #region Female Select
            b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@for='id_gender2']")));
            IWebElement mrs = driver.FindElement(By.XPath("//input[@id='id_gender2']"));
            b.Cursor_Move(driver, mrs);


            //b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/label[@for='id_gender2']")));
            IWebElement c_mrs = mrs.FindElement(By.XPath("//following-sibling::div/span/input[@id='id_gender2']"));
            b.Mouse_Action(driver, mrs);
            // b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//following-sibling::div/span/input[@id='id_gender2']")));

            #endregion



            IWebElement first = driver.FindElement(By.XPath("//input[@id='customer_firstname']"));

            b.Click_SendKeys(driver, first, this.fName);


            IWebElement last = driver.FindElement(By.XPath("//input[@id='customer_lastname']"));
            b.Click_SendKeys(driver, last, this.lName);

            IWebElement password = driver.FindElement(By.XPath("//input[@id='passwd']"));
            b.Click_SendKeys(driver, password, this.Password);

            #region Date Of Birth


            IReadOnlyCollection<IWebElement> dates = driver.FindElements(By.XPath("//select[@id='days']/option"));
            IReadOnlyCollection<IWebElement> months = driver.FindElements(By.XPath("//select[@id='months']/option"));
            IReadOnlyCollection<IWebElement> years = driver.FindElements(By.XPath("//select[@id='years']/option"));

            IWebElement date = driver.FindElement(By.XPath("//select[@id='days']"));
            b.Mouse_Action(driver, date);
            string d;
            foreach (IWebElement element in dates)
            {
                d = element.GetAttribute("value");
                if (d == this.dob_d)
                {
                    element.Click();
                }
            }
            int month_num;
            IWebElement month = driver.FindElement(By.XPath("//select[@id='months']"));
            b.Mouse_Action(driver, month);
            foreach (IWebElement element in months)
            {
                d = element.GetAttribute("value");
                //   m = CultureInfo.CurrentCulture.DateTimeFormat(month);
                month_num = DateTime.ParseExact(this.dob_m, "MMMM", CultureInfo.CurrentCulture).Month;
                // Console.WriteLine(element.Text);
                if (d == month_num.ToString())
                {
                    element.Click();

                }
            }

            IWebElement year = driver.FindElement(By.XPath("//select[@id='years']"));
            b.Mouse_Action(driver, year);
            foreach (IWebElement element in years)
            {
                d = element.GetAttribute("value");
                if (d == this.dob_y)
                {
                    element.Click();
                }
            }
            #endregion

            #region check box

            b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='uniform-newsletter']")));
            IWebElement check_box1 = driver.FindElement(By.XPath("//*[@id='uniform-newsletter']"));
            b.Cursor_Move(driver, check_box1);

            IWebElement checkbox1_click = check_box1.FindElement(By.XPath("//child::input[@id='newsletter']"));
            b.Mouse_Action(driver, checkbox1_click);

            b.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='uniform-optin']")));
            IWebElement check_box2 = driver.FindElement(By.XPath("//*[@id='uniform-optin']"));
            b.Cursor_Move(driver, check_box2);

            IWebElement checkbox2_click = check_box2.FindElement(By.XPath("//child::input[@id='optin']"));
            b.Mouse_Action(driver, checkbox2_click);

            #endregion

            By company = By.XPath("//*[@id='company']");
            Form_Fill(driver, company, b, this.c_name);

            By address = By.XPath("//*[@id='address1']");
            Form_Fill(driver, address, b, this.adr);

            By house_name = By.XPath("//*[@id='address1']//following::input[@id='address2']");
            Form_Fill(driver, house_name, b, "Welcome House");

            By c = By.XPath("//*[@id='city']");
            Form_Fill(driver, c, b, this.city);

            By state = By.XPath("//*[@id='uniform-id_state']");
            Form_Fill(driver, state, b);

            By state_list = By.XPath("//*[@id='uniform-id_state']//child::select[@id='id_state']/option");
            drop_down_list(driver, state_list, this.state);

            By pin = By.XPath("//*[@id='postcode']");
            Form_Fill(driver, pin, b, this.pin_code);

            By add_info = By.XPath("//*[@id='other']");
            Form_Fill(driver, add_info, b, "Nothing");

            By mob = By.XPath("//*[@id='phone_mobile']");
            Form_Fill(driver, mob, b, this.ph);

            b.scroll();

            By submitBtn = By.XPath("//*[@id='submitAccount']");
            Form_Fill(driver, submitBtn, b);


            Thread.Sleep(5000);
        }
        public void Sign_in(IWebDriver driver, Browser b)
        {
            By email = By.XPath("//*[@id='email']");
            Console.WriteLine(Email);
            Console.WriteLine(this.Email);
            this.Email = "Abo@hopefull.com";
            this.Password = "56@oi!AbghuIO";
            Form_Fill(driver, email, b, this.Email);

            By p = By.XPath("//*[@id='email']//following::input[@id='passwd']");
            Form_Fill(driver, p, b, this.Password);

            By sub = By.XPath("//*[@id='email']//following::input[@id='passwd']//following::button[@id='SubmitLogin']");
            Form_Fill(driver, sub, b);
        }

        public void Sign_Out(IWebDriver driver, Browser b)
        {
            By sign_out = By.XPath("//*[@id='header']//child::a[@class='logout']");
            Form_Fill(driver, sign_out, b);
        }
        protected internal void Form_Fill(IWebDriver driver, By by, Browser b)
        {
            /* 
             * The function is intendent to click and element after it is visible
             * or wait 25 seconds maximum to click
             */
            b.wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement element1 = driver.FindElement(by);
            b.Cursor_Move(driver, element1);
            b.Mouse_Action(driver, element1);
        }
        protected internal void Form_Fill(IWebDriver driver, By by, Browser b, string info)
        {
            /*
             * The function is intendent to click and element after it is visible
             * or wait 25 seconds maximum to click and send values to element
             */
            b.wait.Until(ExpectedConditions.ElementIsVisible(by));
            IWebElement element = driver.FindElement(by);
            b.Mouse_Action(driver, element);
            b.Click_SendKeys(driver, element, info);
        }
        protected internal void drop_down_list(IWebDriver driver, By by, string k)
        {
            /* 
             * The function is intendent to check all text or attributes or tags
             * to check with user input
             */
            IReadOnlyCollection<IWebElement> list = driver.FindElements(by);
            foreach (IWebElement element in list)
            {
                if (k == element.Text)
                {
                    element.Click();
                }
            }
        }

    }
}
