using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using XpediaDotComTestProject.Helpers;
using XpediaDotComTestProject.Pages;

namespace XpediaDotComTestProject
{
    [Binding]
    public class XpediaCheapestTicketSteps
    {
        private IWebDriver _driver;
        private MainPage mainPage;
        private FlightsPage flightsPage;
        private decimal cheapestPrice;
        private TicketDetails ticketDetails;

        [BeforeScenario()]
        public void SetUp()
        {
            _driver = new DriverFactory().Create();
            _driver.Navigate().GoToUrl("https://www.expedia.com/");
            mainPage = new MainPage(_driver);
        }
        [Given]
        public void Given_I_select_flights_tab()
        {
            mainPage.GoToFlights();
        }

        [Given]
        public void Given_choose_one_way_trip()
        {
            mainPage.ChooseOneWayTrip();
        }

        [Given]
        public void Given_enter_city_from_P0(string p0)
        {
            mainPage.SetFromCity(p0);
        }

        [Given]
        public void Given_enter_city_to_P0(string p0)
        {
            mainPage.SetToCity(p0);
        }

        [Given]
        public void Given_enter_departing_date_P0(string p0)
        {
            mainPage.SetDepartingDate(p0);
        }

        [Given]
        public void Given_enter_adults_quantity_P0(int p0)
        {
            mainPage.SetAdultsQuantity(p0.ToString());
        }

        [Given]
        public void Given_press_Search_button()
        {
            flightsPage = mainPage.Search();
        }

        [Given]
        public void Given_select_the_cheapest_ticket()
        {
            cheapestPrice = flightsPage.GetCheapestPrice();
        }

        [When]
        public void When_I_press_select_button()
        {
            ticketDetails = flightsPage.GotoBuyTicket(cheapestPrice);
        }

        [Then]
        public void Then_I_should_be_redirected_to_the_ticket_details()
        {
            decimal priceFromTicketDetails = ticketDetails.GetPrice();

            Assert.AreEqual(cheapestPrice, priceFromTicketDetails);
        }

        [AfterScenario()]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
