﻿using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.Web.Excella.Vending.Machine
{

    [Binding]
    public class BuyProductSteps
    {
        private static FeatureContext _context;
        private IWebDriver Browser => _context.Get<IWebDriver>("browser");

        public BuyProductSteps(FeatureContext context)
        {
            _context = context;

            //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            _context.Add("browser", new ChromeDriver());
        }

        private const string HOME_PAGE_URL = "http://localhost:5000/";

        [BeforeTestRun]
        public static void BeforeFeature()
        {
            //IISExpressTestManager.StartIISExpress();
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            Browser.Quit();
            //IISExpressTestManager.StopIISExpress();
        }

        [BeforeScenario]
        public void Setup()
        {
            Browser.Navigate().GoToUrl(HOME_PAGE_URL);
        }

        [AfterScenario]
        public void Teardown()
        {
            var button = Browser.FindElement(By.Id("releaseChange"));
            button.Click();
        }

        [When(@"I insert a Quarter")]
        public void WhenIInsertAQuarter()
        {
            var button = Browser.FindElement(By.Id("insertCoin"));
            button.Click();
        }

        [Then(@"The balance should be (.*) cents")]
        public void TheBalanceShouldBe(int cents)
        {
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            var element = wait.Until(drv => drv.FindElement(By.Id("balanceAmount"))).Text;
            var balance = int.Parse(element);

            Assert.That(balance, Is.EqualTo(cents));
        }

        [Given(@"I have inserted a quarter")]
        public void GivenIHaveInsertedAQuarter()
        {
            var button = Browser.FindElement(By.Id("insertCoin"));
            button.Click();
        }

        [When("I do not purchase a product")]
        public void WhenIDoNotPurchaseAProduct()
        {
            //No-op -- doing nothing here
        }

        [When(@"I purchase a product")]
        public void WhenIPurchaseAProduct()
        {
            // Need to finish this 
        }

        [When(@"I release the change")]
        public void WhenIReleaseTheChange()
        {
            var button = Browser.FindElement(By.Id("releaseChange"));
            button.Click();
        }

        [Then(@"I should receive (.*) cents in change")]
        public void ThenIShouldReceiveXCentsInChange(int cents)
        {
            var wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(10));
            var elementText = wait.Until(drv => drv.FindElement(By.Id("releasedChangeAmount"))).Text;
            var releasedChange = int.Parse(elementText);

            Assert.That(releasedChange, Is.EqualTo(cents));
        }

        [Then(@"I should receive the product")]
        public void ThenIShouldReceiveTheProduct()
        {

            //Assert.IsNotNull(product);
        }

        [Given(@"I have not inserted a quarter")]
        public void GivenIHaveNotInsertedAQuarter()
        {
            // Not calling insert coin
        }

        [Then(@"I should not receive a product")]
        public void ThenIShouldNotReceiveAProduct()
        {
            //Assert.IsNull(product);
        }
    }
}
