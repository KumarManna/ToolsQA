using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing2
{
    internal interface User_Interface
    {   
       void SignUp_Form(IWebDriver driver,Browser b);
       void Sign_in(IWebDriver driver,Browser b);
       void Sign_Out(IWebDriver driver,Browser b); 
    }
    internal interface User_Order
    {
        void Choose(IWebDriver driver,Browser b,Form f);
        void Place_Order(IWebDriver driver,Browser b,Form f);
    }
}
