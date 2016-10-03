using System;
using System.Globalization;
using OpenQA.Selenium;
using XpediaDotComTestProject.Helpers;

namespace XpediaDotComTestProject.Pages
{
    public class TicketDetails
    {
        private IWebDriver _driver;
        public TicketDetails(IWebDriver driver)
        {
            _driver = driver;
        }

        public TicketDetails(IWebDriver driver, string title)
        {
            _driver = driver;
            _driver.WaitForPageLoadedAfterSwitching(title);
        }
        private IWebElement TripSummary {
            get { return new Find(_driver).FindBy(By.Id("trip-summary-title")); }
        }

        private IWebElement TotalPrice {
            get
            {
                return new Find(_driver).FindBy(By.CssSelector("span#trip-summary div#totalContainer span.visuallyhidden"));
            }
        }

        #region Methods

        public decimal GetPrice()
        {
            return decimal.Parse(TotalPrice.Text.Replace("$", String.Empty), new CultureInfo("en-US"));
        }


        public string Trip()
        {
            return TripSummary.Text;
        }
        #endregion
    }
}
