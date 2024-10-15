using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.DataObjects.GreenCart.HomePage;
using UIAutomation.PageObjects;
using UIAutomation.Utilities;

namespace UIAutomation.Tests.GreenCart
{
    internal class GreenCartHomePagePo : BasePo
    {
        public GreenCartHomePagePo(IWebDriver driver) : base(driver)
        {
        }

        
        private readonly By AddToCartButton = By.XPath("//div[@class='product'][1]//child::div[@class='product-action']//button");
        private readonly By CartIcon = By.XPath("//a[@class='cart-icon']");
        private readonly By ProceedToCheckoutButton = By.XPath("//div[@class='action-block']//child::button");
        private readonly By PriceLabelInHomePage = By.XPath("//div[@class='cart-info']//tr[2]//td[3]//strong");
        private readonly By PriceLabelInCHeckOutPopUp = By.XPath("//div[@class='product-total']//p[2]");
        private readonly By ProductQuantityCheckOutPage = By.XPath("//p[@class='quantity']");
        private readonly By ProductAmountCheckOutPage = By.XPath("//table[@id='productCartTables']//tbody//td[4]//p");
        private readonly By TotalAmountCheckOutPage = By.XPath("//table[@id='productCartTables']//tbody//td[5]//p");
        private readonly By PlaceOrderButton = By.XPath("//button[text()='Place Order']");
        private readonly By SelectDropDownValue = By.XPath("//select//option[2]");
        private readonly By AgreeTermsCheckBox = By.XPath("//input[@type='checkbox']");
        private readonly By ProceedButton = By.XPath("//button[text()='Proceed']");

        private readonly By HomePageProductQuantityTextBox = By.XPath("//div[@class='product'][1]//child::input");
        private readonly By HomePageProductName = By.XPath("//div[@class='products'][1]//h4");
        private readonly By HomePageProductPrice = By.XPath("//div[@class='product'][1]//child::p");


        public string GetHomePageProductName()
        {
            return Wait.UntilElementVisible(HomePageProductName).GetText();
        }

        public string GetHomePageProductPrice()
        {
            return Wait.UntilElementVisible(HomePageProductPrice).GetText();
        }

        public void EnterItemQuantityIntoTextBox(HomePageForm homePage)
        {
            EnterQuantity(homePage.Quantity);
        }

        public void EnterQuantity(string Quantity)
        {
            Wait.UntilElementVisible(HomePageProductQuantityTextBox).EnterText(Quantity, true);
        }

       
        public void ClickOnAddToCartButton()
        {
            Wait.UntilElementClickable(AddToCartButton).ClickOn();
        }

        public void ClickOnCartIcon()
        {
            Wait.UntilElementClickable(CartIcon).ClickOn();
        }

        public void ClickOnProceedToCheckOutButton()
        {
            Wait.UntilElementClickable(ProceedToCheckoutButton).ClickOn();
        }

        public string GetPriceLabelInHomePage()
        {
            return Wait.UntilElementVisible(PriceLabelInHomePage).GetText();
        }

        public string GetPriceLabelInCHeckOutPopUp()
        {
            return Wait.UntilElementVisible(PriceLabelInCHeckOutPopUp).GetText();
        }

        public string GetProductQuantityCheckOutPage()
        {
            string ab = Wait.UntilElementVisible(ProductQuantityCheckOutPage).GetText();
            return Wait.UntilElementVisible(ProductQuantityCheckOutPage).GetText();
        }

        public string GetProductAmountCheckOutPage()
        {
            return Wait.UntilElementVisible(ProductAmountCheckOutPage).GetText();
        }

        public string GetTotalAmountCheckOutPage()
        {
            return Wait.UntilElementVisible(TotalAmountCheckOutPage).GetText();
        }

        public void ClickOnPlaceOrderButton()
        {
            Wait.UntilElementClickable(PlaceOrderButton).ClickOn();
        }

        public void SelectValueFromDropDown ()
        {
            Wait.UntilElementClickable(SelectDropDownValue).ClickOn();
        }

        public void ClickOnAgreeTermsCheckBox()
        {
            Wait.UntilElementClickable(AgreeTermsCheckBox).ClickOn();
        }

        public void ClickOnProceedButton()
        {
            Wait.UntilElementClickable(ProceedButton).ClickOn();
        }
    }

    
}
