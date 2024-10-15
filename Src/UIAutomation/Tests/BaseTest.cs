using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using UIAutomation.DataObjects.Device;
using UIAutomation.Enum;
using UIAutomation.Utilities;

namespace UIAutomation.Tests
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected WebDriverFactory DriverFactory = new WebDriverFactory();
        private readonly FileUtil FileUtil = new FileUtil();
        public static Capabilities Capability = new Capabilities();
        public static AppiumLocalService AppiumLocalService;

        //GreenCart URL
        public static string GreenCartUrl;

        protected Logger Log { get; set; }

        public TestContext TestContext { get; set; }


        public static string Env { get; set; }
        public static PlatformName PlatformName { get; set; }

        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            //Browser
            Capability.Browser = testContext.Properties["browser"]?.ToString();
            Env = testContext.Properties["env"]?.ToString();
            Capability.PlatformName = testContext.Properties["PlatformName"]?.ToString();
            PlatformName = Capability.PlatformName.ToEnum<PlatformName>();

            if (PlatformName != PlatformName.Web)
            {
                var args = new OptionCollector()
                 .AddArguments(GeneralOptionList.PreLaunch())
                 .AddArguments(new KeyValuePair<string, string>("--relaxed-security", string.Empty))
                 .AddArguments(new KeyValuePair<string, string>("--allow-insecure", string.Empty))
                 .AddArguments(new KeyValuePair<string, string>("chromedriver_autodownload", string.Empty));
                AppiumLocalService = new AppiumServiceBuilder().WithArguments(args).UsingAnyFreePort().Build();
            }

            


            //GreenCart URL
            GreenCartUrl = $"https://rahulshettyacademy.com/seleniumPractise";
        }

        [TestInitialize]
        public void Setup()
        {
            Log = new Logger($"{FileUtil.GetBasePath()}/Resources/Logs/{SetFileName("Log")}.log");
            Log.Info($"Starting test {TestContext.TestName}");

            //Note: Run for Android Native app
            if (PlatformName.Equals(PlatformName.AndroidApp))
            {
                CleanChromeProfile();
            }
            Driver = DriverFactory.InitDriver(AppiumLocalService, Capability);
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            if (PlatformName != PlatformName.Web)
            {
                AppiumLocalService.Dispose();
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            //Log.Info($"Result - {TestContext.TestName} {TestContext.CurrentTestOutcome.ToString()}");

            //if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            //{
            //    try
            //    {
            //        var screenshotsPath =
            //            $"{FileUtil.GetBasePath()}/Resources/Screenshots/{SetFileName("IMG")}.png";
            //        Driver.TakeScreenShot(screenshotsPath);
            //        TestContext.AddResultFile(screenshotsPath);
            //    }
            //    catch (Exception e)
            //    {
            //        Log.Error(e);
            //    }
            //}
            //try
            //{
            //    TestContext.AddResultFile(Log.LogPath);
            //}
            //catch (Exception e)
            //{
            //    Log.Error(e);
            //}
            //DriverFactory.CloseDriver();
        }

        private string SetFileName(string type)
        {
            var fullyQualifiedTestClassName = TestContext.FullyQualifiedTestClassName.Split('.');
            var className = fullyQualifiedTestClassName[^1];
            var filename = $"[Test]_[{type}]_{new CSharpHelpers().GenerateRandomNumber()}_{className}_{TestContext.TestName}_{DateTime.Now.ToString("yy-MM-dd HH.mm.ss")}";
            if (filename.Length > 70)
            {
                filename = filename.Substring(0, 70);
            }
            return filename;
        }

        private void CleanChromeProfile()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, Capability.DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, Capability.PlatformName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, Capability.PlatformVersion);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, "chrome");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, Capability.AutomationName);
            appiumOptions.AddAdditionalCapability("unicodeKeyboard", "true");
            appiumOptions.AddAdditionalCapability("resetKeyboard", "true");
            appiumOptions.AddAdditionalCapability("appWaitForLaunch", "true");
            Driver = new AndroidDriver<AndroidElement>(AppiumLocalService, appiumOptions);
        }
    }
}
