using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestZbozi
{
    public class KeyWords
    {
        IWebDriver driver;

        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\SeleniumWebDrivers\\chromedriver_win32");
        }

        public void openBrowser()
        {
            driver.Url = "https://www.zbozi.cz/";
            driver.Manage().Window.Maximize();
        }

        public void searchProduct()
        {
            Assert.True(driver.FindElement(By.XPath("//input[@id='q']")).Displayed);
            Assert.True(driver.FindElement(By.XPath("//button[@type='submit']")).Displayed);
            driver.FindElement(By.XPath("//input[@id='q']")).SendKeys("elektrokolo");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

     

        public void useFilterPrice(String f, String t)
        {
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//li[@data-name='cena']//button[contains(@class,'Dropdown')]")).Click();
            driver.FindElement(By.XPath("//input[@ng-model='formData.from']")).Click();
            driver.FindElement(By.XPath("//input[@ng-model='formData.from']")).SendKeys(f);
            driver.FindElement(By.XPath("//input[@ng-model='formData.to']")).Click();
            driver.FindElement(By.XPath("//input[@ng-model='formData.to']")).SendKeys(t);
            driver.FindElement(By.XPath("//button[@class='PriceRangeForm-submit-link']")).Click();
        }


        public void useFilterType()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@data-value='mestske']"));
            driver.FindElement(By.XPath("//a[@data-value='mestske']")).Click();
        }

      

        public void checkProductList()
        {
            driver.FindElements(By.XPath("//ol[@class='results-list default']"));
        }

        public void openFirstProductFromList()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//ul[@id='ListViewInner']//li[contains(@id, 'item')][1]/h3/a")).Displayed);
            driver.FindElement(By.XPath("//ul[@id='ListViewInner']//li[contains(@id, 'item')][1]/h3/a")).Click();
        }
        

        public void closeBrowser()
        {
            driver.Close();
        }

    }
}
