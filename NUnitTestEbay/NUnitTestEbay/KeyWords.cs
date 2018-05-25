using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestEbay
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
            driver.Url = "https://www.ebay.com";
            driver.Manage().Window.Maximize();
        }

        public void searchProduct()
        {
            Assert.IsTrue(driver.FindElement(By.Id("gh-ac")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("gh-btn")).Displayed);
            driver.FindElement(By.Id("gh-ac")).SendKeys("electric bike");
            driver.FindElement(By.Id("gh-btn")).Click();
        }

        public void selectCategory()
        {
            driver.FindElement(By.Id("gh-shop-ei")).Click();
            driver.FindElement(By.XPath("//a[text()='Motorcycles']")).Click();
        }

        public void useFilterPrice(String from, String to)
        {
            Assert.IsTrue(driver.FindElement(By.Id("e1-13")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("e1-14")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("e1-57")).Displayed);
            driver.FindElement(By.Id("e1-13")).SendKeys(from);
            driver.FindElement(By.Id("e1-14")).SendKeys(to);
            driver.FindElement(By.Id("e1-57")).Click();
        }

        public void useFilterCondition(String condition)
        {
            switch (condition)
            {
                case "New":
                    driver.FindElement(By.Id("e1-52")).Click();
                    break;
                case "Used":
                    driver.FindElement(By.Id("e1-54")).Click();
                    break;
                case "Not Specified":
                    driver.FindElement(By.Id("e1-56")).Click();
                    break;
                default:
                    break;
            }
        }

        public void addToCard()
        {
            Assert.IsTrue(driver.FindElement(By.Id("isCartBtn_btn")).Displayed);
            driver.FindElement(By.Id("isCartBtn_btn")).Click();
        }
        
        public void checkListItems()
        {
            IList<IWebElement> all = driver.FindElements(By.XPath("//ul[@id='ListViewInner']//li[contains(@id, 'item')]"));
            String[] allText = new String[all.Count];
            int i = 0;
            foreach (IWebElement element in all)
            {
                allText[i++] = element.Text;
            }
            Assert.IsTrue(allText.Length > 0);
        }


        public void checkProductList()
        {
            driver.FindElements(By.Id("ListViewInner"));
        }

        public void openFirstProductFromList()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//ul[@id='ListViewInner']//li[contains(@id, 'item')][1]/h3/a")).Displayed);
            driver.FindElement(By.XPath("//ul[@id='ListViewInner']//li[contains(@id, 'item')][1]/h3/a")).Click();
        }

        public void verifyNameProduct()
        {
            Assert.IsTrue(driver.FindElement(By.Id("itemTitle")).Displayed);
        }

        public void verifyNameProductFromBucket()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(@id, 'sellerBucket')][1]//div[@class='mr10']//a")).Displayed);
        }

        public void clickProceedToCheckout()
        {
            Assert.IsTrue(driver.FindElement(By.Id("ptcBtnBottom")).Displayed);
            driver.FindElement(By.Id("ptcBtnBottom")).Click();
        }

        public void closeBrowser()
        {
            driver.Close();
        }

    }
}
