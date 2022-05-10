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
            foreach (IWebElement webElement in nav)
            {
                by = By.XPath(p + i.ToString() + q);
                T = driver.FindElement(By.XPath(p + i.ToString() + q));

                b.Mouse_Hover(driver, T);
                Thread.Sleep(1000);
                Console.WriteLine(p + i.ToString() + q);
                //f.Form_Fill(driver,by,b);
                i++;
                if (i > 3)
                    break;
                //b.wait.Until()

            }
            f.Sign_in(driver,b);
            By h = By.XPath("//div[@id='block_top_menu']/ul/li[2]");
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

           // bool S_In= f.Sign_in(driver,b);
            b.scroll();

            By proceed_check = By.XPath("//*[@id='ordermsg']");
            f.Form_Fill(driver, proceed_check, b,"Deliver soon");
            SubmitORContinue(driver, 1, b);
            b.scroll();
            
           SubmitORContinue(driver,1, b);
            f.Form_Fill(driver, proceed_check, b, "Deliver soon");
            SubmitORContinue(driver,1, b);
            SubmitORContinue(driver, 1, b);
            By cb = By.Id("cgv");
            f.Form_Fill(driver, cb, b);
            b.scroll();
            By a = By.XPath("//*[@class='cart_navigation clearfix']//child::*[@name='processCarrier']");
         //  b.wait.Until(ExpectedConditions.ElementToBeClickable(a));
            IWebElement d = driver.FindElement(a);
            b.wait.Until(ExpectedConditions.ElementToBeClickable(a));
            b.Mouse_Action(driver, d);
          //  f.Form_Fill(driver,a, b);
          //  driver.SwitchTo().Window(driver.CurrentWindowHandle);
            
            
            SubmitORContinue(driver,1, b);
            b.scroll();
            Payment(driver,b);

            SubmitORContinue(driver,1, b);
        }
        public void Order_TShirt(IWebDriver driver, Browser b, Form f)
        {
            By image = By.XPath("//*[@class='product-image-container']");
            b.Mouse_Hover(driver, driver.FindElement(image));
            By more = By.XPath("//div[@class='right-block']//child::a[2]");
            b.Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(1000);
            //*[@class='table-data-sheet']//child::tr[1]
            string t1 = "//*[@class='table-data-sheet']//child::tr[";
            string t2 = "]/td[";
            string t3 = "]";
            IReadOnlyCollection<IWebElement> e;
            int j;
            IDictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 1; i <= 3; i++)
            {
                //Console.WriteLine(i);
                e = driver.FindElements(By.XPath(t1 + i.ToString() + "]"));
                j = 1;
                foreach (IWebElement s in e)
                {
                    //Console.WriteLine(s.Text);
                    // driver.FindElement(By.XPath(t1 + j.ToString() + t2 + i.ToString() + t3));
                    while (j <3) { 
                       // Console.WriteLine(t1 + i.ToString() + t2 + j.ToString() + t3);
                        //Console.WriteLine(driver.FindElement(By.XPath(t1 + i.ToString() + t2 + j.ToString() + t3)).Text);
                        d.Add(driver.FindElement(By.XPath(t1 + i.ToString() + "]")).Text, driver.FindElement(By.XPath(t1 + i.ToString() + t2 + j.ToString() + t3)).Text);
                           j++;
                        if (j == 2)
                            break;
                     }
                }
                //Console.WriteLine(t1 + i.ToString() + "]");
                foreach(KeyValuePair<string,string> dic in d)
                {
                    Console.WriteLine(dic.Key, dic.Value);
                }
                
            }
            string item_name = driver.FindElement(By.XPath("//*[@itemprop='name']")).Text;
            By s1 = By.XPath("//*[@id='search_query_top']");
            f.Form_Fill(driver, s1, b, item_name);
            By search = By.XPath("//*[@id='search_query_top']//following-sibling::button");
            f.Form_Fill(driver, search, b);
            Thread.Sleep(1000);
            b.scroll();
            b.scroll();

            IDictionary<string, string> d1 = new Dictionary<string, string>();
            for (int i = 1; i <= 3; i++)
            {
                //Console.WriteLine(i);
                e = driver.FindElements(By.XPath(t1 + i.ToString() + "]"));
                j = 1;
                foreach (IWebElement s in e)
                {
                    //Console.WriteLine(s.Text);
                    // driver.FindElement(By.XPath(t1 + j.ToString() + t2 + i.ToString() + t3));
                    while (j < 3)
                    {
                        // Console.WriteLine(t1 + i.ToString() + t2 + j.ToString() + t3);
                        //Console.WriteLine(driver.FindElement(By.XPath(t1 + i.ToString() + t2 + j.ToString() + t3)).Text);
                        d1.Add(driver.FindElement(By.XPath(t1 + i.ToString() + "]")).Text, driver.FindElement(By.XPath(t1 + i.ToString() + t2 + j.ToString() + t3)).Text);
                        j++;
                        if (j == 2)
                            break;
                    }
                }
                //Console.WriteLine(t1 + i.ToString() + "]");
                
            }
            Console.WriteLine("---------------------------------------");
            foreach (KeyValuePair<string, string> dic in d1)
            {
                Console.WriteLine(dic.Key, dic.Value);
            }
            Console.WriteLine(d1.Equals(d));
            Thread.Sleep(2000);
        }
        public void Payment(IWebDriver driver, Browser b)
        {
            Form f=new Form();
            By c_o = By.XPath("//*[@id='HOOK_PAYMENT']/div[1]");
            f.Form_Fill(driver, c_o, b);
        }
        public void SubmitORContinue(IWebDriver driver,int i,Browser b)
        {
            Form f = new Form();
            string p = "//*[@class='cart_navigation clearfix']/a[";
            string q = "]";
            By SC=By.XPath(p+i.ToString()+q);
            f.Form_Fill(driver,SC,b);
        }
    }
}
