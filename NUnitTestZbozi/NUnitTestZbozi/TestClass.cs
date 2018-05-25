using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestZbozi
{
	[TestFixture]
	public class TestClass : KeyWords
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
         *  Step 1: open zbozi.cz page
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
			checkProductList();
		}

		 /*  
         *  ID : TC _002
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
         *  Expected result: displayed product list
         *  --------------------------------------------------------
         *  Step 4: Use filter Type = mestske
         *  Expected result: displayed product list
         *  --------------------------------------------------------
         *  
         */
		[Test]
		public void selectProductAndUseFilter()
		{
			openBrowser();
			searchProduct();
			useFilterPrice("1000", "20000");
			useFilterType();
			checkProductList();
		}


		[TearDown]
		public void close_Browser()
		{
			closeBrowser();
		}
	}
}
