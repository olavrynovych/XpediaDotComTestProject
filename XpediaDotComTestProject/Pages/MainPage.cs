using OpenQA.Selenium;
using XpediaDotComTestProject.Helpers;

namespace XpediaDotComTestProject.Pages
{
    public class MainPage
    {
        private IWebDriver _driver;
        
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement FlightTab {
            get { return new Find(_driver).FindBy(By.Id("tab-flight-tab")); }
        }

        private IWebElement OneWayTripBtn {
            get { return new Find(_driver).FindBy(By.Id("flight-type-one-way-label"));}
        }

        private IWebElement FlightFromField
        {
            get { return new Find(_driver).FindBy(By.Id("flight-origin")); }
        }

        private IWebElement FlightToField
        {
            get { return new Find(_driver).FindBy(By.Id("flight-destination")); }
        }

        private IWebElement  DepartingDateField {
            get { return new Find(_driver).FindBy(By.Id("flight-departing"));}
        }

        private IWebElement ReturningDateFiled {
            get { return new Find(_driver).FindBy(By.Id("flight-returning"));}
        }

        private IWebElement AdultsDropDown {
            get { return new Find(_driver).FindBy(By.Id("flight-adults"));}
        }

        private IWebElement SearchBtn {
            get { return new Find(_driver).FindBy(By.Id("search-button"));}
        }

       

        #region Methods
        public void GoToFlights()
        {
            _driver.WaitForPageLoaded(15);
            FlightTab.Click();
        }

        public void ChooseOneWayTrip()
        {
            OneWayTripBtn.Click();
        }

        public void SetFromCity(string city)
        {
            FlightFromField.SendKeys(city);
        }

        public void SetToCity(string city)
        {
            FlightToField.SendKeys(city);
        }

        public void SetDepartingDate(string date)
        {
            DepartingDateField.SendKeys(date);
        }

        public void SetReturningDate(string date)
        {
            ReturningDateFiled.SendKeys(date);
        }

        public void SetAdultsQuantity(string number)
        {
            AdultsDropDown.SendKeys(number);
        }

        public FlightsPage Search()
        {
            SearchBtn.Click();
            return new FlightsPage(_driver);
        }

       
        #endregion

    }
}
