using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestEbay
{
    [TestFixture]
    public class EbayTest : KeyWords
    {
        [SetUp]
        public void start_Browser()
        {
            startBrowser();
        }

        /*  
     *  ID : TC _001
     *  --------------------------------------------------------
     *  Title: Search product
     *  --------------------------------------------------------
     *  Step 1: open ebay page
     *  Expected result: page opened
     *  --------------------------------------------------------
     *  Step 2: Set text in search field and click Search.
     *  Expected result: displayed product items in list
     *  --------------------------------------------------------
     */
       [Test]
       public void search_product()
       {
           openBrowser();
           searchProduct();
       }

       /*  
     *  ID : TC _002
     *  --------------------------------------------------------
     *  Title: Select product using Category
     *  --------------------------------------------------------
     *  Step 1: open ebay page
     *  Expected result: page opened
     *  --------------------------------------------------------
     *  Step 2: Select Category "Motorcycles" in drop down menu
     *  Expected result: displayed selected items in list
     *  --------------------------------------------------------  
     */
        [Test]
       public void selectCategoryInDropDownMenu()
       {
           openBrowser();
           selectCategory();
           checkListItems();
       }

       /*  
      *  ID : TC _003
      *  --------------------------------------------------------
      *  Title: Search product using filter
      *  --------------------------------------------------------
      *  Step 1: open ebay page
      *  Expected result: page opened
      *  --------------------------------------------------------
      *  Step 2: add to search field text "electric bike", click Search
      *  Expected result: displayed product list
      *  --------------------------------------------------------
      *  Step 3: Use filter Price from 1000 to 20000
      *  Expected result: displayed product list with price from 1000 to 20000
      *  --------------------------------------------------------
      *  Step 4: Use filter Condition = New
      *  Expected result: displayed new products
      *  --------------------------------------------------------
      *  Step 5: check 
      *  Expected result: displayed new products
      *  
      */
        [Test]
        public void selectProductAndUseFilter()
        {
            openBrowser();
            searchProduct();
            useFilterPrice("1000", "20000");
            useFilterCondition("New");
            checkProductList();
        }

        /*  
      *  ID : TC _004
      *  --------------------------------------------------------
      *  Title: Select first product
      *  --------------------------------------------------------
      *  Step 1: open ebay page
      *  Expected result: page opened
      *  --------------------------------------------------------
      *  Step 2: add to search field text "electric bike", click Search
      *  Expected result: displayed product list
      *  --------------------------------------------------------
      *  Step 3: select first product from list result
      *  Expected result: product page opened
      *  --------------------------------------------------------
      *  Step 4: Verify product name
      *  Expected result: product name is correct
      */
        [Test]
        public void openFirstProduct()
        {
            openBrowser();
            searchProduct();
            openFirstProductFromList();
            verifyNameProduct();
        }


        /*  
         *  ID : TC _005
         *  --------------------------------------------------------
         *  Title: Buy Product
         *  --------------------------------------------------------
         *  Step 1: open ebay page
         *  Expected result: page opened
         *  --------------------------------------------------------
         *  Step 2: add to search field text "electric bike", click Search
         *  Expected result: displayed product list
         *  --------------------------------------------------------
         *  Step 3: select first product from list result
         *  Expected result: product page opened
         *  --------------------------------------------------------
         *  Step 4: click "add to Card"
         *  Expected result: bucket page opened. 
         *  --------------------------------------------------------
         *  Step 5: verify product name in Bucket
         *  Expected result: product name is correct
         *  --------------------------------------------------------
         *  Step 6: click button "Proceed To Checkout"
         *  Expected result: redirect to page Ebay Sign in
         */
        [Test]
        public void buyFirstProduct()
        {
            openBrowser();
            searchProduct();
            openFirstProductFromList();
            addToCard();
            verifyNameProductFromBucket();
            clickProceedToCheckout();
        }

        [TearDown]
        public void close_Browser()
        {
            closeBrowser();
        }

    }

}
