using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAutomation.DataObjects.DynamicGreenCart.HomePage;
using UIAutomation.PageObjects.DynamicGreenCartDemo.SearchBarFunctionality;
using UIAutomation.Utilities;

namespace UIAutomation.Tests.DynamicGreenCart.SearchBarFunctionality
{
    [TestClass]
    [TestCategory("Smoke")]
    public class TopDealsTest : BaseTest
    {
        #region "Constant Variables"
        private static readonly JObject homePageData = JObject.Parse(File.ReadAllText(new FileUtil().GetBasePath() + "/TestData/DynamicGreenCartDemo/Jsons/HomePageData.json"));
        List<HomePageForm> productDetails = new List<HomePageForm>();
        #endregion

        [TestMethod]
        public void VerifySearchFunctionalityIsWorkingSuccessfully()
        {
            var searchTextBox = new TopDealsPo(Driver);

            Log.Info($"Step 1: Navigate to application at: {GreenCartUrl}");
            Driver.NavigateTo(GreenCartUrl);

            Log.Info($"Step 2: Click on 'Top Deals' link");
            searchTextBox.ClickOnTopDealsLink();
            Driver.SwitchToLastWindow();

            Log.Info($"Step 3: Enter Vegetable name and verify products detail  available in list");
            productDetails = homePageData["home"].ToObject<List<HomePageForm>>();
            int i = 0;
            searchTextBox.EnterVegetableName("Wheat");
            //foreach (HomePageForm product in productDetails)
            //{
            //    if (i.Equals(0))
            //    {
            //        searchTextBox.EnterVegetableName("Wheat");
            //    }
            //    i++;
            //}
            Assert.AreEqual(searchTextBox.GetVegetableSearchTextBoxValue(),
                searchTextBox.GetVegetableNameFromList("Wheat"), "Vegetable Name Doesn't Match");

            Log.Info($"Step 4: select page size '10' and verify vegetable list contains '10' items");
            searchTextBox.pressEscKey();
            searchTextBox.SelectPageSize("10");
            searchTextBox.GetVegetableCountList();
            Assert.AreEqual("10", searchTextBox.GetVegetableCountList(),
                "List size doen't match");
        }
    }
}
