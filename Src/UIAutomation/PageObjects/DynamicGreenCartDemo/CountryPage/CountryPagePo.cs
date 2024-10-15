using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.DynamicGreenCartDemo.CountryPage
{
    internal class CountryPagePo : BasePo
    {
        public CountryPagePo(IWebDriver driver) : base(driver)
        {
        }

        #region "Read Only Varirables"
        private readonly By CountryDropdown = By.XPath("//select//option[2]");
        private readonly By AgreeTermsCheckBox = By.XPath("//input[@type='checkbox']");
        private readonly By ProceedButton = By.XPath("//button[text()='Proceed']");
        #endregion

        #region "Click Methods"
        public void CountryPageChooseValueFromCountryDropDown()
        {
            Wait.UntilElementClickable(CountryDropdown).ClickOn();
        }
        public void CountryPageAgreeTermsCheckBox()
        {
            Wait.UntilElementClickable(AgreeTermsCheckBox).ClickOn();
        }

        public void CountryPageProceedButton()
        {
            Wait.UntilElementClickable(ProceedButton).ClickOn();
        }
        #endregion
    }



}
