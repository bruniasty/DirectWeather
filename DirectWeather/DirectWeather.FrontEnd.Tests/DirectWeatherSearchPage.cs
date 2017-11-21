namespace DirectWeather.FrontEnd.Tests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;

    public class DirectWeatherSearchPage
    {
        private static IWebDriver driver;

        public static DirectWeatherSearchPage NavigateTo(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Navigate().GoToUrl("http://localhost:9758");
            var searchPage = new DirectWeatherSearchPage();
            PageFactory.InitElements(driver, searchPage);
            return searchPage;
        }
     
        public void FillCountry(string country)
        {
            var countryElement = driver.FindElement(By.Name("country"));
            countryElement.SendKeys(country);
        }

        public void FillCity(string city)
        {
            var cityElement = driver.FindElement(By.Name("city"));
            cityElement.SendKeys(city);
        }
        
        public void SubmitForm()
        {
            var submitElement = driver.FindElement(By.Name("submit"));
            submitElement.Click();
        }

        public (string humidity, string temperature) GetResults()
        {
            var humidityOutput = FindElement(By.Id("HumidityOutput"), 20);
            var temperatureOutput = driver.FindElement(By.Id("TemperatureOutput"));

            if (humidityOutput != null && temperatureOutput != null)
            {
                return (humidity: humidityOutput.Text, temperature: temperatureOutput.Text);
            }

            return (humidity: null, temperature: null);
        }
        
        private static IWebElement FindElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
            }

            return driver.FindElement(by);
        }
    }
}