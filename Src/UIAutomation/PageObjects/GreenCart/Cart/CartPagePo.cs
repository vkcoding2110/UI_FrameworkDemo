using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.GreenCart.Cart
{
    internal class CartPagePo : BasePo
    {
        public CartPagePo(IWebDriver driver) : base(driver)
        {
        }

        private readonly By CartPageProductQuantity = By.XPath("//div[@class='products']//p[@class='quantity']");
        private readonly By CartPageProductName = By.XPath("//div[@class='products']//p[@class='product-name']");
        private readonly By CartPageProductPrice = By.XPath("//tbody//td[4]//p[@class='amount']");
        private readonly By CartPageTotalAmount = By.XPath("//tbody//td[5]//p[@class='amount']");
        private readonly By CartPagePlaceOrderButton = By.XPath("//button[text()='Place Order']");

        public string GetCartPageProductName()
        {
            return Wait.UntilElementVisible(CartPageProductName).GetText();
        }
        public string GetCartPageProductQuantity()
        {
            return Wait.UntilElementVisible(CartPageProductQuantity).GetText();
        }

        public string GetCartPageProductPrice()
        {
            return Wait.UntilElementVisible(CartPageProductPrice).GetText();
        }

        public string GetCartPageTotalAmount()
        {
            return Wait.UntilElementVisible(CartPageTotalAmount).GetText();
        }

        public void ClickOnPlaceOrderButton()
        {
            Wait.UntilElementClickable(CartPagePlaceOrderButton).ClickOn();
        }

    }
}
