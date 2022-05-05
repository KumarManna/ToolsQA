using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Testing
{
    partial class ToolsQa
    {
        public void Dropable()
        {
            url = "https://demoqa.com/droppable";
            IWebDriver driver = Open_Url();

            IWebElement s = driver.FindElement(By.XPath("//div/nav[contains(@class,'nav nav-tabs') and contains(@role,'tablist')]/a[1]"));
            actions(driver).MoveToElement(s).Click().Build().Perform();
            Simple(driver);

            IWebElement a = driver.FindElement(By.XPath("//div/nav[contains(@class,'nav nav-tabs') and contains(@role,'tablist')]/a[2]"));
            actions(driver).MoveToElement(a).Click().Build().Perform();
            Accept(driver);

            IWebElement d = driver.FindElement(By.XPath("//div/nav[contains(@class,'nav nav-tabs') and contains(@role,'tablist')]/a[3]"));
            actions(driver).MoveToElement(d).Click().Build().Perform();
            Drag_Box(driver);


            IWebElement r = driver.FindElement(By.XPath("//div/nav[contains(@class,'nav nav-tabs') and contains(@role,'tablist')]/a[4]"));
            actions(driver).MoveToElement(r).Click().Build().Perform();
            Revert_Dragable(driver);
            close_quit();
        }

        private void Simple(IWebDriver driver)
        {
            IWebElement drop_box = driver.FindElement(By.XPath("//*[@id='droppable']"));

            IWebElement drop_ele = driver.FindElement(By.XPath("//*[@id='draggable']"));

            actions(driver).DragAndDrop(drop_ele, drop_box).Build().Perform();
            //Click_Action(driver, drop_box, drop_ele);

        }

        private void Accept(IWebDriver driver)
        {
            IWebElement ac = driver.FindElement(By.XPath("//div[@class='accept-drop-container']//child::div[@id='acceptable']"));
            IWebElement nac = driver.FindElement(By.XPath("//div[@class='accept-drop-container']//child::div[@id='notAcceptable']"));
            IWebElement drop_box = driver.FindElement(By.XPath("//div[@class='accept-drop-container']//child::div[@id='droppable']"));

            jex = (IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,100)");

            Click_Action(driver, nac, drop_box);
            //  actions(driver).DragAndDrop(nac, drop_box).Release().Perform();
            Click_Action(driver, ac, drop_box);
        }

        private void Drag_Box(IWebDriver driver)
        {
            IWebElement drag_me = driver.FindElement(By.XPath("//div[@id='ppDropContainer']/div[@id='dragBox']"));
            IWebElement outer_ng_box = drag_me.FindElement(By.XPath("//following::div[@id='notGreedyDropBox']"));
            IWebElement inner_ng_box = outer_ng_box.FindElement(By.XPath("//following::div[@id='notGreedyInnerDropBox']"));

            Click_Action(driver, drag_me, outer_ng_box);
            Click_Action(driver,drag_me, inner_ng_box);

            IWebElement outer_ig_box = drag_me.FindElement(By.XPath("//following::div[@id='greedyDropBox']"));
            IWebElement inner_ig_box = outer_ig_box.FindElement(By.XPath("//following-sibling::div[@id='greedyDropBoxInner']"));

            Click_Action(driver, drag_me, outer_ig_box);
            Click_Action(driver, drag_me, inner_ig_box);
        }

        private void Revert_Dragable(IWebDriver driver)
        {
            IWebElement will_revert = driver.FindElement(By.XPath("//*[@id='revertable']"));
          
            IWebElement not_revert = will_revert.FindElement(By.XPath("//following-sibling::div[@id='notRevertable']"));
          
            IWebElement drop_box = will_revert.FindElement(By.XPath("//div[@id='revertable']//following::div[@id='droppable']"));


            //jex = (IJavaScriptExecutor)driver;
            //jex.ExecuteScript("window.scrollBy(0,100)");
            //actions(driver).DragAndDrop(will_revert, drop_box).Build().Perform();
            //Thread.Sleep(100);
            //actions(driver).DragAndDrop(not_revert, drop_box).Build().Perform();
           Click_Action(driver,will_revert,drop_box);
            Click_Action(driver, not_revert, drop_box);
        }

        private void Click_Action(IWebDriver driver,IWebElement target,IWebElement source)
        {
            jex = (IJavaScriptExecutor)driver;
            jex.ExecuteScript("window.scrollBy(0,100)");
            actions(driver).DragAndDrop(target, source).Build().Perform();
           
            //actions(driver).DragAndDrop(target, source).Build().Perform();
            Thread.Sleep(100);
        }

    }
}
