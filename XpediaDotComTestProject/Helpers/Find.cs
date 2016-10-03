using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using XpediaDotComTestProject.Interfaces;

namespace XpediaDotComTestProject.Helpers
{
    public class Find
    {
        private IWebDriver _driver;
        private ILogger logger = new ConsoleLogger();

        public Find(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FindByWithCondition(Func<IWebDriver, IWebElement> condition, int waitSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitSeconds));
                IWebElement element = wait.Until(condition);
                return element;
            }
            catch (Exception ex)
            {
                logger.Log(ex, condition.ToString());
                throw;
            }
        }
    

        public IWebElement FindBy(By by, int waitTimeout=0)
        {
            if (waitTimeout != 0)
            {
                return FindByWithWait(by, waitTimeout);
            }
            else
            {
                return FindBy(by);
            }
            
        }

        private IWebElement FindByWithWait(By by, int waitTimeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTimeout));
                IWebElement elememt = wait.Until(d => d.FindElement(by));
                return elememt;
            }
            catch (Exception ex)
            {
                logger.Log(ex,by.ToString());
                throw;
            }
        }

        private IWebElement FindBy(By by)
        {
            try
            {
                return _driver.FindElement(by);
            }
            catch (Exception ex)
            {
                logger.Log(ex, by.ToString());
                throw;
            }
        }

    }

    
}
