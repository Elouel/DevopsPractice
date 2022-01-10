namespace Tests
{
    using DevopsTest.Controllers;
    using Xunit;
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var weatherService = new WeatherForecastService();

            Assert.True(weatherService.GetWeatherForecast().Length == 7);
        }
    }
}