namespace DirectWeather.FrontEnd.Tests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding]
    public class LocalWeatherInAGivenCitySteps
    {
        private DirectWeatherSearchPage searchPage;
        private IWebDriver driver;

        [BeforeScenario]
        public void Setup()
        {
            this.driver = new ChromeDriver();
        }

        [AfterScenario]
        public void TearDown()
        {
            this.driver.Quit();
        }

        [Given(@"a webpage with a form")]
        public void GivenAWebpageWithAForm()
        {
            this.searchPage = DirectWeatherSearchPage.NavigateTo(this.driver);
        }
        
        [Given(@"I type '(.*)' in country form")]
        public void GivenITypeInCountryForm(string p0)
        {
            this.searchPage.FillCountry(p0);
        }
        
        [Given(@"I type '(.*)' in city form")]
        public void GivenITypeInCityForm(string p0)
        {
            this.searchPage.FillCity(p0);
        }
        
        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            this.searchPage.SubmitForm();
        }
        
        [Then(@"I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForWarsawPolandAccordingToTheOfficialWeatherReports()
        {
            this.CheckHumidityAndTemperatureResult();
        }

        [Then(@"I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForGdanskPolandAccordingToTheOfficialWeatherReports()
        {
            this.CheckHumidityAndTemperatureResult();
        }

        [Then(@"I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports")]
        public void ThenIReceiveTheTemperatureAndHumidityConditionsOnTheDayForBerlinGermanyAccordingToTheOfficialWeatherReports()
        {
            this.CheckHumidityAndTemperatureResult();
        }

        private void CheckHumidityAndTemperatureResult()
        {
            var result = this.searchPage.GetResults();
            Assert.NotEmpty(result.humidity);
            Assert.NotEmpty(result.temperature);
        }
    }
}
