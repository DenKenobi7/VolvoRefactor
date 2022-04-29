using System;
using System.Collections.Generic;
using VolvoRefactor.Application.Helpers;
using VolvoRefactor.Application.Models;
using VolvoRefactor.Application.TaxCalculators;
using Xunit;

namespace VolvoRefactor.UnitTests.Factories
{
    public class CongestionTaxCalculatorFactoryTests
    {
        private readonly CongestionTaxCalculatorFactory _factory;

        public CongestionTaxCalculatorFactoryTests()
        {
            var congestionConfiguration = new CongestionConfiguration
            {
                MaxDailyFee = 50,
                SingleChargeTime = 60,
                TollFreeVehicles = new List<string> { "Emergency" },
                CongestionIntervalCosts = new List<CongestionIntervalCost> { new("06:00", "06:30", 8) },
                HolidaysSet = new()
                {
                    DaysOfWeek = new() { "Saturday" },
                    Months = new() { 7 },
                    HolidayDates = new() { DateHelper.DateFromString("01.01.2013") }
                }
            };
            _factory = new CongestionTaxCalculatorFactory(congestionConfiguration);
        }

        [Theory]
        [InlineData(typeof(GothenburgCongestionTaxCalculator), "Gothenburg")]
        [InlineData(typeof(CustomCongestionTaxCalculator), "Custom")]
        public void GetCalculatorByName_ExistingCityCalculator_ReturnsAppropriateCalculator(Type expectedCalculatorType, string city)
        {
            //Arrange

            //Act
            var result = _factory.GetCalculatorByName(city).GetType();

            //Assert

            Assert.Equal(expectedCalculatorType, result);
        }

        [Fact]
        public void GetCalculatorByName_NotExistingCityCalculator_ReturnsCustomCalculator()
        {
            //Arrange
            var testCity = "TestCity";

            //Act
            var result = _factory.GetCalculatorByName(testCity).GetType();

            //Assert

            Assert.Equal(typeof(CustomCongestionTaxCalculator), result);
        }
    }
}
