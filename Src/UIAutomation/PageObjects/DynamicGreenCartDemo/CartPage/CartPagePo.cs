using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.DynamicGreenCartDemo.CartPage
{
    internal class CartPagePo : BasePo
    {
        public CartPagePo(IWebDriver driver) : base(driver)
        {
        }

        #region "Static Variables"
        private static By CartPageProductName(string ProductName) => By.XPath($"//div[@class='products']//p[@class='product-name' and text()='{ProductName}']");
        private static By CartPageProductQuantity(string ProductName) => By.XPath($"//p[@class='product-name' and text()='{ProductName}']//parent::td//parent::tr//p[@class='quantity']");
        private static By CartPageProductAmount(string ProductName) => By.XPath($"//p[@class='product-name' and text() = '{ProductName}']//parent::td//parent::tr//td[4]//p[@class='amount']");
        private static By CartPageProductTotalAmount(string ProductName) => By.XPath($"//p[@class='product-name' and text() = '{ProductName}']//parent::td//parent::tr//td[5]//p[@class='amount']");
        #endregion

        #region "Read Only Variables"
        private readonly By CartPageTotalAmountLabel = By.XPath("//span[@class='totAmt']");

        private readonly By CartPagePlaceOrderButton = By.XPath("//button[text()='Place Order']");
        #endregion

        #region "Get Methods"
        public string GetCartPageProductName(string ProductName)
        {
            string ab = Wait.UntilElementVisible(CartPageProductName(ProductName)).GetText();
            return Wait.UntilElementVisible(CartPageProductName(ProductName)).GetText();
        }
        public string GetCartPageProductQuantity(string ProductName)
        {
            return Wait.UntilElementVisible(CartPageProductQuantity(ProductName)).GetText();
        }
        public string GetCartPageProductAmount(string ProductName)
        {
            return Wait.UntilElementVisible(CartPageProductAmount(ProductName)).GetText();
        }
        public string GetCartPageProductTotalAmount(string ProductName)
        {
            return Wait.UntilElementVisible(CartPageProductTotalAmount(ProductName)).GetText();
        }

        public string GetCartPageTotalAmountLabel()
        {
            string ab = Wait.UntilElementVisible(CartPageTotalAmountLabel).GetText();
            return Wait.UntilElementVisible(CartPageTotalAmountLabel).GetText();
        }
        #endregion

        #region "Click Methods"
        public void ClickOnCartPagePlaceOrderButton()
        {
            Wait.UntilElementClickable(CartPagePlaceOrderButton).ClickOn();
        }
        #endregion
    }
}
