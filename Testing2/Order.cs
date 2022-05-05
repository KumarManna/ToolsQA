using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;

namespace Testing2
{
    internal class Order:User_Order
    {
        public void Choose(IWebDriver driver, Browser b, Form f )
        {
            
            // //div[@id='block_top_menu']/ul/li[1]
            string p = "//div[@id='block_top_menu']/ul/li[";
            string q="]";
            IReadOnlyCollection<IWebElement> nav=driver.FindElements(By.XPath("//div[@id='block_top_menu']//child::li"));
            int i = 1;
            IWebElement T;
            By by;
            //foreach(IWebElement webElement in nav)
            //{
            //    by = By.XPath(p + i.ToString() + q);
            //    T = driver.FindElement(By.XPath(p + i.ToString() + q));

            //    b.Mouse_Hover(driver, T);
            //    Thread.Sleep(1000);
            //    Console.WriteLine(p + i.ToString() + q);
            //    //f.Form_Fill(driver,by,b);
            //    i++;
            //    if (i > 3)
            //        break;
            //    //b.wait.Until()

            //}
           // By h = By.XPath("//div[@id='block_top_menu']/ul/li[2]");
            IWebElement hover1= driver.FindElement(By.XPath("//div[@id='block_top_menu']/ul/li[2]"));
            b.Mouse_Hover(driver, hover1);
            By  cas_dress = By.XPath("//div[@id='block_top_menu']/ul/li[2]//child::li[1]");
            //b.Mouse_Hover(driver, cas_dress);
            //b.wait.Until(ExpectedConditions.ElementToBeClickable(cas_dress));
            //b.Mouse_Action(driver,cas_dress);
            b.scroll();
            f.Form_Fill(driver, cas_dress, b);

            Place_Order(driver, b, f);
        }
        public void Place_Order(IWebDriver driver, Browser b, Form f)
        {
            IWebElement product = driver.FindElement(By.XPath("//*[@class='product-image-container']"));
            b.Mouse_Hover(driver, product);
            //div[contains(@class,'right-block')]//child::div[@class='button-container']/a[1]
            By add = By.XPath("//div[contains(@class,'right-block')]//child::div[@class='button-container']/a[1]");
            f.Form_Fill(driver, add, b);
            By check_out = By.XPath("//*[@id='layer_cart']//child::div[@class='button-container']/a");
            f.Form_Fill(driver,check_out,b);
            By proceed = By.XPath("//*[@class='cart_navigation clearfix']/a[1]");
            f.Form_Fill (driver, proceed, b);
            f.Sign_in(driver,b);
            b.scroll();

            By proceed_check = By.XPath("//*[@id='ordermsg']");
            f.Form_Fill(driver, proceed_check, b,"Deliver soon");
            SubmitORContinue(driver, f, 1, b);
            b.scroll();
            b.scroll();
            By a = By.XPath("//span[contains(text(), 'Proceed to checkout')]");
         //  b.wait.Until(ExpectedConditions.ElementToBeClickable(a));
            IWebElement d = driver.FindElement(a);
            b.wait.Until(ExpectedConditions.ElementToBeClickable(a));
            b.Mouse_Action(driver, d);
          //  f.Form_Fill(driver,a, b);
          //  driver.SwitchTo().Window(driver.CurrentWindowHandle);
            By cb = By.Id("cgv");
            f.Form_Fill(driver, cb, b);
            b.scroll();
            SubmitORContinue(driver, f, 1, b);
            b.scroll();
            Payment(driver,f,b);

            SubmitORContinue(driver,f, 1, b);
        }
        public void Payment(IWebDriver driver, Form f,Browser b)
        {
            By c_o = By.XPath("//*[@id='HOOK_PAYMENT']/div[1]");
            f.Form_Fill(driver, c_o, b);
        }
        public void SubmitORContinue(IWebDriver driver,Form f ,int i,Browser b)
        {
            string p = "//*[@class='cart_navigation clearfix']/a[";
            string q = "]";
            By SC=By.XPath(p+i.ToString()+q);
            f.Form_Fill(driver,SC,b);
        }
    }
}
