using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using UIAutomation.DataFactory.GreenCart;
using UIAutomation.PageObjects.GreenCart.Cart;
using UIAutomation.PageObjects.GreenCart.Country;
using UIAutomation.PageObjects.GreenCart.HomePage;
using UIAutomation.Utilities;

namespace UIAutomation.Tests.GreenCart.HomePage
{
    [TestClass]
    [TestCategory("Smoke")]
    public class HomePageTest : BaseTest
    {
        private  readonly string _ExpectedProductName = "Brocolli - 1 Kg";
        [TestMethod]
        public void VerifyUserCanOrderItemsSuccessfully()
        {
            var homePage = new GreenCartHomePagePo(Driver);
            var header = new HeaderPo(Driver);
            var cart = new CartPagePo(Driver);
            var countryPo = new CountryPo(Driver);
            

            Log.Info($"Step 1: Navigate to application at: {GreenCartUrl}");
            Driver.NavigateTo(GreenCartUrl);

            Log.Info($"Step 2: Enter item quantity &  click on 'Add To Cart' Button ");
            var addQuantity = VegetableDataFactory.EnterItemQuantity();
            homePage.EnterItemQuantityIntoTextBox(addQuantity);
            homePage.ClickOnAddToCartButton();
            Assert.AreEqual(_ExpectedProductName, homePage.GetHomePageProductName(), "Product Name doesn't match");
            // Get Expected Product Name and Price

            string homePageProductName = homePage.GetHomePageProductName();
            string homePageProductPrice = homePage.GetHomePageProductPrice();

            Log.Info($"Step 3: Click on 'Cart' icon & verify the products price, quantity and product name");
            homePage.ClickOnCartIcon();
            Assert.AreEqual(homePage.GetHomePageProductName(), header.GetHeaderProductName(),"Product Name doesn't match");
            Assert.AreEqual(Convert.ToString(int.Parse(homePage.GetHomePageProductPrice()) * int.Parse(addQuantity.Quantity)), header.GetHeaderProductPrice(), "Product Price doesn't match");

            Log.Info($"Step 4: Click on 'PROCEED TO CHECKOUT' button & verify products price, quantity , product name and total amount is displayed correct");
            homePage.ClickOnProceedToCheckOutButton();
            Assert.AreEqual(homePageProductName, cart.GetCartPageProductName(), "Product Name doesn't match");
            Assert.AreEqual(homePageProductPrice, cart.GetCartPageProductPrice(), "Product Price doesn't match");
            string getProductQuantity = cart.GetCartPageProductQuantity();
            string getProductAmount = cart.GetCartPageProductPrice();
            string getTotalAmount = cart.GetCartPageTotalAmount();
            string calculationResult = Convert.ToString(double.Parse(getProductQuantity) * double.Parse(getProductAmount));
            Assert.AreEqual(getTotalAmount, calculationResult);


            Log.Info($"Step 5: Click on 'Place Order' Button");
            cart.ClickOnPlaceOrderButton();

            Log.Info($"Step 9: Select 'Country' from Dropdown & click on 'Agree Terms & Conditions' Checkbox");
            countryPo.ChooseCountryValueFromDropDown();
            countryPo.ClickOnAgreeTermsCheckBox();


            Log.Info("Step 11: Click on 'Proceed' Button & Verify 'Thank You' page gets open");
            countryPo.ClickOnProceedButton();
            //Put thank you page assertion
            Thread.Sleep(10000);
        }
    }
}
