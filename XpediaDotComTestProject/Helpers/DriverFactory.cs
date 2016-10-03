using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XpediaDotComTestProject.Helpers
{
    public enum DriverToUse
    {
        Chrome,
        InternetExplorer,
        Firefox
    }

    public class DriverFactory
    {
        public IWebDriver Create()
        {
            IWebDriver driver;
            DirectoryInfo dir;
            do
            {
                var curr = Directory.GetCurrentDirectory();
                dir = Directory.GetParent(curr);
                Directory.SetCurrentDirectory(dir.FullName);
            } while (dir.Name != "XpediaDotComTestProject");

            var path = @"D:\MyProjects\QAProjects\XpediaDotComTestProject\XpediaDotComTestProject";//Directory.GetCurrentDirectory();//
            var driverToUse = ConfigurationManager.AppSettings["DriverToUse"];
            switch (driverToUse)
            {
                case nameof(DriverToUse.Chrome):
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentException($"There are no implementation for this type of browser: '{driverToUse}' ");
            }
            driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();
            timeouts.ImplicitlyWait(TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["ImplicitlyWait"])));

            return driver;
        }
    }
}
