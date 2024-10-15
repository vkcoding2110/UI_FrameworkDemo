using OpenQA.Selenium;
using UIAutomation.DataFactory.GreenCart;
using UIAutomation.DataObjects.GreenCart.HomePage;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.DynamicGreenCartDemo.HomePage
{
    internal class HomePagePo : BasePo
    {
        public HomePagePo(IWebDriver driver) : base(driver)
        {
        }

        #region "Static Variables"
        private static By HomePageProductName(string ProductName) => By.XPath($"//div[@class='product']//h4[text()='{ProductName}']"); 
        private static By HomePageProductAddtoCartButton(string ProductName) => By.XPath($"//h4[text()= '{ProductName}']//parent::div[@class='product']//child::div[@class='product-action']//button");
        private static By HomePageProductQuantity(string ProductName) => By.XPath($"//h4[text()='{ProductName}']//parent::div[@Class='product']//child::input");
        private static By HomePageProductPrice(string ProductName) => By.XPath($"//h4[text()='{ProductName}']//parent::div//p[@class='product-price']");
        #endregion

        #region "Read Only Variables"
        private readonly By CartIcon = By.XPath("//a[@class='cart-icon']");
        #endregion

        #region "Enter Methods"
        public void EnterProductQuantity(string ProductName,string productQuantity)
        {
            Wait.UntilElementVisible(HomePageProductQuantity(ProductName)).EnterText(productQuantity, true);
        }
        #endregion

        #region "Click Methods"
        public void ClickOnAddToCartButton(string ProductName)
        {
            Wait.UntilElementClickable(HomePageProductAddtoCartButton(ProductName)).ClickOn();
        }
        public void ClickOnCartIcon()
        {
            Wait.UntilElementClickable(CartIcon).ClickOn();
        }
        #endregion

        #region "Get Methods"
        public string GetHomePageProductName(string ProductName)
        {
            return Wait.UntilElementVisible(HomePageProductName(ProductName)).GetText();
        }

        public string GetHomePageProductPrice(string ProductName)
        {
            return Wait.UntilElementVisible(HomePageProductPrice(ProductName)).GetText();
        }
        #endregion
    }
}
