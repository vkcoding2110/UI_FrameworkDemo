using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.DataObjects.DynamicGreenCart.HomePage;
using UIAutomation.PageObjects.DynamicGreenCartDemo.CartPage;
using UIAutomation.PageObjects.DynamicGreenCartDemo.CountryPage;
using UIAutomation.PageObjects.DynamicGreenCartDemo.HomePage;
using UIAutomation.Utilities;

namespace UIAutomation.Tests.DynamicGreenCart.HomePage
{
    [TestClass]
    [TestCategory("Smoke")]
    public class HomePageTest : BaseTest
    {
        #region "Constant Variable"
        private static readonly JObject homePageData = JObject.Parse(File.ReadAllText(new FileUtil().GetBasePath() + "/TestData/DynamicGreenCartDemo/Jsons/HomePageData.json"));
        List<HomePageForm> productDetails = new List<HomePageForm>();
        double totalAmountLabel = 0;
        #endregion

        #region "VerifyUserCanOrderItemsSuccessfully"
        [TestMethod]
        public void VerifyUserCanOrderItemsSuccessfully()
        {
            var homePage = new HomePagePo(Driver);
            var headerPage = new HeaderPo(Driver);
            var cartPage = new CartPagePo(Driver);
            var countryPage = new CountryPagePo(Driver);

            Log.Info($"Step 1: Navigate to application at: {GreenCartUrl}");
            Driver.NavigateTo(GreenCartUrl);

            Log.Info($"Step 2: Add Quantity in 'Quantity' textbox and Click on 'Add to Cart' Button");
            productDetails = homePageData["home"].ToObject<List<HomePageForm>>();
            foreach(HomePageForm product in productDetails)
            {
                homePage.EnterProductQuantity(product.ProductName, product.ProductQuantity);
                homePage.ClickOnAddToCartButton(product.ProductName);
                //_ProductName.Add(homePage.GetHomePageProductName(product.ProductName));
                //_ProductAmount.Add(homePage.GetHomePageProductPrice(product.ProductName));
            }

            Log.Info($"Step 3: Click on 'Cart' Logo");
            homePage.ClickOnCartIcon();

            Log.Info($"Step 4: Verify products price,  product name is displayed correctly");
            foreach(HomePageForm product1 in productDetails)
            {              
                Assert.AreEqual(homePage.GetHomePageProductName(product1.ProductName), headerPage.GetHeaderProductName(product1.ProductName),
                    "Product Name doesn't match");
                Assert.AreEqual(homePage.GetHomePageProductPrice(product1.ProductName), headerPage.GetHeaderProductPrice(product1.ProductName),
                    "Product Price doesn't match");
            }

            Log.Info($"Step 5: Click on 'Proceed to Checkout' Button ");
            headerPage.ClickOnProceedToCheckOutButton();

            Log.Info($"Step 6: Verify product price, product name  and total amount is displayed correctly");
            int i = 0;
            foreach (HomePageForm product2 in productDetails)
            {
                Assert.AreEqual(product2.ProductName, cartPage.GetCartPageProductName(product2.ProductName),
                    "Product Name doesn't match");
                Assert.AreEqual(product2.ProductQuantity, cartPage.GetCartPageProductQuantity(product2.ProductName),
                    "Product Price doesn't match");

                string Quantity = cartPage.GetCartPageProductQuantity(product2.ProductName);
                string Amount = cartPage.GetCartPageProductAmount(product2.ProductName);
                string totalAmount = Convert.ToString(double.Parse(Quantity) * double.Parse(Amount));

                Assert.AreEqual(totalAmount, cartPage.GetCartPageProductTotalAmount(product2.ProductName));
                totalAmountLabel += Convert.ToDouble(totalAmount);
                i++;
            }

            Log.Info($"Step 7: Verify 'Total Amount' is displayed correctly and then click on 'Place Order' Button");
            Assert.AreEqual(Convert.ToString(totalAmountLabel), cartPage.GetCartPageTotalAmountLabel());
            cartPage.ClickOnCartPagePlaceOrderButton();

            Log.Info($"Step 8: Choose value from 'Country' Dropdown, click on 'Agree Terms & Condition' and click on 'Proceed' Button");
            countryPage.CountryPageChooseValueFromCountryDropDown();
            countryPage.CountryPageAgreeTermsCheckBox();
            countryPage.CountryPageProceedButton();
        }
        #endregion
    }
}
