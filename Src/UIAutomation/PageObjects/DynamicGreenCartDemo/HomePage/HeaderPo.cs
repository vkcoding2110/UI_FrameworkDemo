using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.PageObjects;
using UIAutomation.Utilities;

namespace UIAutomation.DataObjects.DynamicGreenCart.HomePage
{
    internal class HeaderPo : BasePo
    {
        public HeaderPo(IWebDriver driver) : base(driver)
        {
        }

        #region "Static Variables"
        private static By HeaderProductName(string ProductName) => By.XPath($"//div[@class='cart']//child::div[2]//child::div//child::div//child::ul//child::li//child::div[@class='product-info']//child::p[text()='{ProductName}']");
        private static By HeaderProductPrice(string ProductName) => By.XPath($"//div[@class='cart']//child::div[2]//child::div//child::div//child::ul//child::li//child::div[@class='product-info']//child::p[text()='{ProductName}']//parent::div//p[2][@class='product-price']");
        private static By HeaderProductQuantity(string ProductName) => By.XPath($"//p[@class='quantity']//parent::div//parent::li//child::div[@class='product-info']//p[@class='product-name' and text()='{ProductName}']//parent::div//parent::li//parent::ul//parent::div//parent::div//parent::div[@class='cart-preview active']");
        
        private static By HeaderProceedToCheckOutButton = By.XPath("//div[@class='action-block']//child::button");
        #endregion

        #region "Get Methods"
        public string GetHeaderProductName(string ProductName)
        {
            return Wait.UntilElementVisible(HeaderProductName(ProductName)).GetText();
        }
        public string GetHeaderProductPrice(string ProductName)
        {
            return Wait.UntilElementVisible(HeaderProductPrice(ProductName)).GetText();
        }
        public string GetHeaderProductQuantity(string ProductName)
        {
            return Wait.UntilElementVisible(HeaderProductQuantity(ProductName)).GetText();
        }
        #endregion

        #region "Click Methods"
        public void ClickOnProceedToCheckOutButton()
        {
            Wait.UntilElementClickable(HeaderProceedToCheckOutButton).ClickOn();
        }
        #endregion
    }
}
