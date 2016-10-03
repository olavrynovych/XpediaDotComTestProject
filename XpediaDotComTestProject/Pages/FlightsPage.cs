using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using XpediaDotComTestProject.Helpers;

namespace XpediaDotComTestProject.Pages
{
    public class FlightsPage
    {
        private IWebDriver _driver;

        public FlightsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IList<IWebElement> PriceElements
        {
            get { return PricesTable.FindElements(By.CssSelector(".price-column.price-split-line")); } 
        }

        private IWebElement PricesTable
        {
            get { return new Find(_driver).FindByWithCondition(ExpectedConditions.ElementToBeClickable(By.Id("flightModuleList"))); }
        }

        private KeyValuePair<List<decimal>, List<IWebElement>> _tableTickets
        {
            get { return GetTableTickets(); }
        }

        private IWebElement ProgressBarDiv
        {
            get { return new Find(_driver).FindBy(By.Id("pi-interstitial")); }
        }

        #region Methods
        private void WaitUntilProgressBarDisappear(int time=10)
        {
            if (ProgressBarDiv != null)
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
                wait.Until((drv) => !ProgressBarDiv.Displayed);
            }
        }

        private KeyValuePair<List<decimal>, List<IWebElement>> GetTableTickets()
        {
            WaitUntilProgressBarDisappear(15);
            var pricesList = new List<decimal>();
            var elementsList = new List<IWebElement>();
            //Getting prices from the table, parsing and put to 2 Lists
            foreach (var priceElement in PriceElements)
            {
                decimal price = Decimal.Parse(priceElement.GetAttribute("data-test-price-per-traveler")
                    .Replace("$", String.Empty), new CultureInfo("en-US"));
                pricesList.Add(price);
                elementsList.Add(priceElement);
            }
            return new KeyValuePair<List<decimal>, List<IWebElement>>(pricesList,elementsList);
        }

        private KeyValuePair<decimal, IWebElement> GetTheCheapestTicket()
        {
            decimal price = _tableTickets.Key.Min();
            int indexOfCheapestTicket = _tableTickets.Key.IndexOf(price);
            return new KeyValuePair<decimal, IWebElement>(price, _tableTickets.Value[indexOfCheapestTicket]);
        }

        public TicketDetails GotoBuyTicket(decimal price)
        {
            var ticket = GetTicketElement(price);
            ticket.FindElement(By.XPath(@"//button[@class='btn-secondary btn-action t-select-btn']")).Click();
            return new TicketDetails(_driver, "Trip Detail | Expedia");
        }

        public IWebElement GetTicketElement(decimal price)
        {
            int index = _tableTickets.Key.IndexOf(price);
            return _tableTickets.Value[index];
        }

        public decimal GetCheapestPrice()
        {
            return GetTheCheapestTicket().Key;
        }

        public void BuyCheapestTicket()
        {
            decimal cheapestPrice = GetCheapestPrice();
            GotoBuyTicket(cheapestPrice);
        }

        #endregion
    }
}
