using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace Testing
{
    class MainClass1
    {
        //https://docs.google.com/forms/d/e/1FAIpQLScs1EQtjewiPDt4Kkngxui_2Wn3pty9Cj_iLBNPH88zWhWSGA/viewform
        static void Main()
        {
            ToolsQa toolsQa = new ToolsQa();
            //toolsQa.TestBox_Test();
            //toolsQa.Radio_Button_Test();
            //toolsQa.Web_Tables_Test();
            //toolsQa.Click_Test();
            //toolsQa.LinkTest();
            //toolsQa.BrokenLink_Test();
            // toolsQa.Upload_Download_Test();
            //toolsQa.Dynamic_Properties_Test();
            //toolsQa.LinkTest();
            //toolsQa.Browser_Windows();
            //toolsQa.Alerts();
            //toolsQa.Frame();
            //toolsQa.NestedFrame();
            //toolsQa.Modal();
            //toolsQa.Accordian();
            //toolsQa.Date_Picker();
            // toolsQa.Slider();
            //  toolsQa.Progress_Bar();
            //toolsQa.Tab();
            //toolsQa.ToolTips();
            //toolsQa.MenuHover();
            //toolsQa.Selectable();
            //CheckBox.main();
            //toolsQa.Resize
            toolsQa.Form();
         //   toolsQa.Dropable();

        }
    }
}
