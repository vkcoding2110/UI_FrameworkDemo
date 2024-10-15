using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.Tests;
using UIAutomation.Utilities;

namespace UIAutomation.PageObjects.GreenCart.Country
{
    internal class CountryPo : BasePo
    {
        public CountryPo(IWebDriver driver) : base(driver)
        {
        }

        private readonly By CountryDropDown = By.XPath("//select//option[2]");
        private readonly By AgreeTermsCheckBox = By.XPath("//input[@type='checkbox']");
        private readonly By ProceedButton = By.XPath("//button[text()='Proceed']");

        public void ChooseCountryValueFromDropDown()
        {
            Wait.UntilElementClickable(CountryDropDown).ClickOn();
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
