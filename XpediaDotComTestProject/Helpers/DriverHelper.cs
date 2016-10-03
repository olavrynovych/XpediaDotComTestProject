using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using XpediaDotComTestProject.Interfaces;

namespace XpediaDotComTestProject.Helpers
{
    public static class DriverHelper
    {
        public static bool WaitForPageLoaded(this IWebDriver driver, int timeSeconds=10)
        { 
            bool documentReady = false;
            for (int i = 0; i < timeSeconds*5; i++)
            {
                if (documentReady)
                    return true;
                documentReady = driver.ExecuteJavaScript<string>(@"return document.readyState") == "complete";
                Thread.Sleep(200);
            }
            return false;
        }

        public static void WaitForPageLoadedAfterSwitching(this IWebDriver driver, string title, int timeoutSeconds = 30)
        {
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds <= timeoutSeconds * 1000)
            {
                if (driver.Title==title)
                    return;
                Thread.Sleep(200);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
            }
            if (driver.Title != title)
            {
                throw new NoSuchWindowException($"Wrong title for the page. Should be: '{title}', but is: '{driver.Title}'");
            }
                
        }

    }
}
