using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            Thread.Sleep(100);
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
            }
            foreach (KeyValuePair<string, string> dic in d)
            {
                Console.WriteLine(dic.Key, dic.Value);
            }
            string item_name = driver.FindElement(By.XPath("//*[@itemprop='name']")).Text;
            By s1 = By.XPath("//*[@id='search_query_top']");
            f.Form_Fill(driver, s1, b, item_name);
            Thread.Sleep(100);
            By search = By.XPath("//*[@id='search_query_top']//following-sibling::button");
            f.Form_Fill(driver, search, b);
            Thread.Sleep(1000);
            b.scroll();
            b.scroll();

           
            b.Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            b.Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(1000);
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
           
           
            bool equal = false;
            if (d.Count == d1.Count) // Require equal count.
            {
                equal = true;
                foreach (var pair in d)
                {
                    string value;
                    if (d1.TryGetValue(pair.Key, out value))
                    {
                        // Require value be equal.
                        if (value != pair.Value)
                        {
                            equal = false;
                            break;
                        }
                    }
                    else
                    {
                        // Require key be present.
                        equal = false;
                        break;
                    }
                }
            }
            Console.WriteLine(equal);
        }

        public void Second_Order(IWebDriver driver, Browser b, Form f)
        {
            //div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]
            By t1 = By.XPath("//div[@id='block_top_menu']/ul/li[1]");
            b.Mouse_Hover(driver,driver.FindElement(t1));
            By t2 = By.XPath("//div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]/a");
            b.Mouse_Hover(driver, driver.FindElement(t2));
            f.Form_Fill(driver, t2, b);
            By image = By.XPath("//*[@class='product-image-container']");
            b.Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            By more = By.XPath("//div[@class='right-block']//child::a[2]");
            b.Cursor_Move(driver, driver.FindElement(more));
            b.Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(100);
            By inc = By.XPath("//*[@id='quantity_wanted_p']//child::a[2]");
            f.Form_Fill(driver, inc, b);
            By size_c = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']");
            f.Form_Fill(driver, size_c, b);
            Thread.Sleep(1000);
            string o = "//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option[@value='";
            By size_option = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option");
            
            IReadOnlyCollection<IWebElement> list = driver.FindElements(size_option);
            Console.WriteLine(list.Count);
            string t,v;
            foreach (IWebElement element in list)
            {
                t = element.Text;
                v = element.GetAttribute("value");
                if ("L" == t)
                {
                    element.Click();
                    break;
                }
                Console.WriteLine(o + v.ToString() + "']");


            }
            Thread.Sleep(100);
            b.scroll();
            By or = By.XPath("//*[@id='color_to_pick_list']/li[2]/a");
            f.Form_Fill(driver, or, b);
            Thread.Sleep(100);
            b.scroll();
            By sub = By.XPath("//*[@id='add_to_cart']//child::button");
            f.Form_Fill(driver, sub, b);
            Thread.Sleep(100);
            By check_out_btn1 = By.XPath("//*[@class='button-container']//child::a");
            f.Form_Fill(driver, check_out_btn1, b);
            Thread.Sleep(100);
            b.scroll();
            By check_out_btn2 = By.XPath("//*[@class='cart_navigation clearfix']/a");
            f.Form_Fill(driver, check_out_btn2, b);
            Thread.Sleep(100);
            f.Sign_in(driver,b);
            Thread.Sleep(100);
            By check_out_btn3 = By.XPath("//*[@class='cart_navigation clearfix']//child::button");
            f.Form_Fill(driver, check_out_btn3, b);
            Thread.Sleep(100);
            b.scroll();
            b.scroll();
            // By check_box = By.XPath("//*[@id='uniform-cgv']//child::input[@id='cgv']");
            By check_box = By.Id("cgv");
            b.Mouse_Hover(driver, driver.FindElement(check_box));
            b.Mouse_Action(driver, driver.FindElement(check_box));
            //f.Form_Fill(driver, check_box, b);
            Thread.Sleep(100);
            //*[@class='cart_navigation clearfix']//child::button
            f.Form_Fill(driver, check_out_btn3, b);
            Thread.Sleep(100);
            b.scroll();
            By pay_bank_wire = By.XPath("//*[@id='HOOK_PAYMENT']//child::p/a");
            f.Form_Fill(driver, pay_bank_wire, b);
           
            b.scroll();
            Thread.Sleep(100);
            f.Form_Fill(driver, check_out_btn3, b);
            b.scroll();
            Thread.Sleep(5000);
        }

        public void Add_To_WishList(IWebDriver driver,Browser b,Form f)
        {
            By t1 = By.XPath("//div[@id='block_top_menu']/ul/li[1]");
            b.Mouse_Hover(driver, driver.FindElement(t1));
            By t2 = By.XPath("//div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]/a");
            b.Mouse_Hover(driver, driver.FindElement(t2));
            f.Form_Fill(driver, t2, b);
            By image = By.XPath("//*[@class='product-image-container']");
            b.Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            By wl = By.XPath("//*[@class='functional-buttons clearfix']//child::a");
            b.Mouse_Hover(driver, driver.FindElement(wl));
            Thread.Sleep(10);
            f.Form_Fill(driver, wl, b);
            Thread.Sleep(1000);
            By e_txt = By.XPath("//*[@class='fancybox-skin']//child::p");
            string error_txt = driver.FindElement(e_txt).Text;
            Console.WriteLine(error_txt);
            
            if(error_txt== "You must be logged in to manage your wishlist.")
            {
                Console.WriteLine("Test case passed");
            }
            else
            {
                Console.WriteLine("Failed");//*[@class='fancybox-skin']//child::p
            }
            Thread.Sleep(10000);
        }

        public void Shopping_Cart_Summary_Page(IWebDriver driver,Browser b,Form f)
        {
            By t1 = By.XPath("//div[@id='block_top_menu']/ul/li[1]");
            b.Mouse_Hover(driver, driver.FindElement(t1));
            By t2 = By.XPath("//div[@id='block_top_menu']/ul/li[1]//child::li[1]//child::li[1]/a");
            b.Mouse_Hover(driver, driver.FindElement(t2));
            f.Form_Fill(driver, t2, b);
            By image = By.XPath("//*[@class='product-image-container']");
            b.Mouse_Hover(driver, driver.FindElement(image));
            Thread.Sleep(100);
            By more = By.XPath("//div[@class='right-block']//child::a[2]");
            b.Cursor_Move(driver, driver.FindElement(more));
            b.Mouse_Action(driver, driver.FindElement(more));
            Thread.Sleep(100);
            b.scroll();
            By min_item = By.XPath("//*[@id='quantity_wanted_p']//child::input");
            string min_num = driver.FindElement(min_item).GetAttribute("value");
            if (min_num == "1")
                Console.WriteLine("Test case 1 passed");
            else
                Console.WriteLine("Test case 1 not passed");

            By size_c = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']");
            f.Form_Fill(driver, size_c, b);
            Thread.Sleep(1000);
            string o = "//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option[@value='";
            By size_option = By.XPath("//*[@id='attributes']//child::*[@id='uniform-group_1']//child::*[@id='group_1']/option");

            IReadOnlyCollection<IWebElement> list = driver.FindElements(size_option);
            Console.WriteLine(list.Count);
            string t, v;
            foreach (IWebElement element in list)
            {
                t = element.Text;
                v = element.GetAttribute("value");
                if ("M" == t)
                {
                    element.Click();
                    break;
                }
                Console.WriteLine(o + v.ToString() + "']");
            }
            Thread.Sleep(100);
            b.scroll();
            By or = By.XPath("//*[@id='color_to_pick_list']/li[2]/a");
            f.Form_Fill(driver, or, b);
            By sub = By.XPath("//*[@id='add_to_cart']//child::button");
            f.Form_Fill(driver, sub, b);
            Thread.Sleep(100);
            By check_out_btn1 = By.XPath("//*[@class='button-container']//child::a");
            f.Form_Fill(driver, check_out_btn1, b);
            Thread.Sleep(100);
            string price1 = driver.FindElement(By.XPath("//*[@id='cart_summary']//child::td[6]/span")).Text;
            //*[@id='cart_summary']//child::td[6]/span
            //string q = price1.Remove(0);
            //float p1 = float.Parse(q);
            Console.WriteLine(price1);
            By inc = By.XPath("//*[@class='cart_quantity_button clearfix']/a[2]");
            f.Form_Fill(driver,inc,b);
            Thread.Sleep(2000);
            b.scroll();
            b.scroll();
            //string price2 = driver.FindElement(By.XPath("//*[@id='cart_summary']//child::td[6]/span")).Text;
            //Console.WriteLine(price2);
            string tp = driver.FindElement(By.XPath("//*[@id='total_price_container']/span")).Text;
          //  Thread.Sleep(1000);
            Console.WriteLine(tp);
            //price2.Remove(0);
            //float p2 = float.Parse(price2.Remove(0).ToString());
            //Console.WriteLine(p2);
            //float total = p1 * 2;
            //  Console.WriteLine("Total price {0}",total);
            if ("$35.02" == tp)
            {
                Console.WriteLine("Test case 3 passed");
            }
            else
            {
                Console.WriteLine("Test case 3 not passed");
            }
            Thread.Sleep(1000000);
            


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
