//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using XpediaDotComTestProject.Helpers;
//using XpediaDotComTestProject.Pages;

//namespace XpediaDotComTestProject.Tests
//{
//    [TestClass]
//    public class Test
//    {
//        public static IWebDriver Driver;

//        [ClassInitialize]
//        public static void SetUp(TestContext s)
//        {
//            Driver = new DriverFactory().Create();
//        }
//        [TestMethod]
//        [TestCategory("Test")]
//        public void TestMethod()
//        {
//            Driver.Navigate().GoToUrl("https://www.expedia.com/");
//            var mainPage = new MainPage(Driver);
//            mainPage.GoToFlights();
//            mainPage.ChooseOneWayTrip();
//            mainPage.SetFromCity("Kiev");
//            mainPage.SetToCity("Amsterdam");
//            mainPage.SetDepartingDate("12/04/2016");
//            mainPage.SetAdultsQuantity("1");
//            var flightsPage = mainPage.Search();

//            decimal cheapestPrice = flightsPage.GetCheapestPrice();
//            var details = flightsPage.GotoBuyTicket(cheapestPrice);
            
//            decimal priceFromTicketDetails = details.GetPrice();

//            Assert.AreEqual(cheapestPrice, priceFromTicketDetails);
//        }
//        [ClassCleanup]
//        public static void AfterTest()
//        {
//            Driver.Quit();
//        }
//    }
//}
