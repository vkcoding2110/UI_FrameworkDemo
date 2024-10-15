using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.GreenCart.HomePage
{
    internal class HeaderPo : BasePo
    {
        public HeaderPo(IWebDriver driver) : base(driver)
        {
        }

        private readonly By HeaderProductName = By.XPath("//div[contains(@class,'cart-preview')]//p[@class='product-name']");
        private readonly By HeaderProductQuantity = By.XPath("//div[contains(@class,'cart-preview')]//p[@class='quantity']");
        private readonly By HeaderProductPrice = By.XPath("//div[contains(@class,'cart-preview')]//p[@class='amount']");

        public string GetHeaderProductName()
        {
            return Wait.UntilElementVisible(HeaderProductName).GetText();
        }

        public string GetHeaderProductQuantity()
        {
            return Wait.UntilElementVisible(HeaderProductQuantity).GetText().Replace(" Nos.", "");
        }

        public string GetHeaderProductPrice()
        {
            return Wait.UntilElementVisible(HeaderProductPrice).GetText();
        }
    }
}
