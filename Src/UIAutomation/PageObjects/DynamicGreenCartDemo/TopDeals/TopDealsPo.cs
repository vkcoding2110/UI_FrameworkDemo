using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.DataObjects.DynamicGreenCart.HomePage;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.DynamicGreenCartDemo.SearchBarFunctionality
{
    internal class TopDealsPo:BasePo
    {
        public TopDealsPo(IWebDriver driver) : base(driver)
        {
            
        }

        #region "Read Only Variables"
        private readonly By SearchBarTopDealsLink = By.XPath("//a[text()='Top Deals']");
        private readonly By SearchBarSearchTextBox = By.XPath("//input[@id='search-field']");
        private readonly By VegetableList = By.XPath("//tbody//tr");
        

        #endregion

        #region "Static Variables"
        private static By SearchBarVegFruitName(string ProductName) => By.XPath($"//td[text()='{ProductName}']");
        private static By PageSize(string PageSizeVariable) => By.XPath($"//select[@id='page-menu']//child::option[@value='{PageSizeVariable}']");
        #endregion

        #region "Click Methods"
        public void ClickOnTopDealsLink()
        {
            Wait.UntilElementClickable(SearchBarTopDealsLink).ClickOn();
            Wait.HardWait(5000);
           
        }
        public void SelectPageSize(string PageSizeVariable)
        {
            Wait.UntilElementClickable(PageSize(PageSizeVariable)).ClickOn();
        }
        #endregion

        #region "Enter Methods"
        public void EnterVegetableName(string VegetableName)
        {
            Wait.UntilElementVisible(SearchBarSearchTextBox).EnterText(VegetableName);
        }
        #endregion

        #region "Get Methods"
        public string GetVegetableSearchTextBoxValue()
        {
            return Wait.UntilElementVisible(SearchBarSearchTextBox).GetAttribute("value");
        }

        public string GetVegetableNameFromList(string VegetableName)
        {
            return Wait.UntilElementVisible(SearchBarVegFruitName(VegetableName)).GetText();
        }

        public string GetVegetableCountList()
        {
            //string getVegetableList = Convert.ToString(Wait.UntilAllElementsLocated(VegetableList).Count);
            return Convert.ToString(Wait.UntilAllElementsLocated(VegetableList).Count);
        }

        #endregion

        #region "Clear Methods"
        public void clearSearchTextBox()
        {
             Wait.UntilElementVisible(SearchBarSearchTextBox).Clear();
        }

        public void pressEscKey()
        {
            Wait.UntilElementVisible(SearchBarSearchTextBox).PressEscKey();
        }
        #endregion
    }


}
