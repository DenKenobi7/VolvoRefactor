using System;
using System.Collections.Generic;
using VolvoRefactor.Application.Helpers;
using VolvoRefactor.Application.Models;
using VolvoRefactor.Application.TaxCalculators;
using VolvoRefactor.UnitTests.Utils;
using Xunit;

namespace VolvoRefactor.UnitTests.Calculators
{
    public class CustomCongestionTaxCalculatorTests
    {
        private readonly CustomCongestionTaxCalculator _calculator;
        private readonly DateTime[] _checkpoints;

        public CustomCongestionTaxCalculatorTests()
        {
            var congestionConfiguration = new CongestionConfiguration
            {
                City = "TestCity",
                MaxDailyFee = 50,
                SingleChargeTime = 60,
                TollFreeVehicles = new List<string>
                {
                    "Emergency",
                    "Diplomat",
                    "Military",
                    "Foreign"
                },
                CongestionIntervalCosts = new List<CongestionIntervalCost>
                {
                    new("06:00","06:30",8),
                    new("06:30","07:00",13),
                    new("07:00","08:00",18),
                    new("08:00","08:30",13),
                    new("08:30","15:00",8),
                    new("15:00","15:30",13),
                    new("15:30","17:00",18),
                    new("17:00","18:00",13),
                    new("18:00","18:30",8),
                    new("18:30","06:00",0),
                },
                HolidaysSet = new()
                {
                    DaysOfWeek = new()
                    {
                        "Saturday",
                        "Sunday"
                    },
                    Months = new()
                    {
                        7
                    },
                    HolidayDates = new()
                    {
                        DateHelper.DateFromString("01.01.2013"),
                        DateHelper.DateFromString("06.01.2013"),
                        DateHelper.DateFromString("29.03.2013"),
                        DateHelper.DateFromString("31.03.2013"),
                        DateHelper.DateFromString("01.04.2013"),
                        DateHelper.DateFromString("01.05.2013"),
                        DateHelper.DateFromString("09.05.2013"),
                        DateHelper.DateFromString("19.05.2013"),
                        DateHelper.DateFromString("06.06.2013"),
                        DateHelper.DateFromString("22.06.2013"),
                        DateHelper.DateFromString("02.11.2013"),
                        DateHelper.DateFromString("24.12.2013"),
                        DateHelper.DateFromString("25.12.2013"),
                        DateHelper.DateFromString("26.12.2013"),
                        DateHelper.DateFromString("31.12.2013"),
                    }
                }
            };

            _calculator = new CustomCongestionTaxCalculator(congestionConfiguration);
            var stringCheckpoints = new string[]
            {
                "2013-01-14 21:00:00",
                "2013-01-15 21:00:00",
                "2013-02-07 06:23:27",
                "2013-02-07 15:27:00",
                "2013-02-08 06:27:00",
                "2013-02-08 06:20:27",
                "2013-02-08 14:35:00",
                "2013-02-08 15:29:00",
                "2013-02-08 15:47:00",
                "2013-02-08 16:01:00",
                "2013-02-08 16:48:00",
                "2013-02-08 17:49:00",
                "2013-02-08 18:29:00",
                "2013-02-08 18:35:00",
                "2013-03-26 14:25:00",
                "2013-03-28 14:07:27"
            };
            _checkpoints = stringCheckpoints.GetDatesFromStrings();
        }

        [Fact]
        public void GetTax_HolidayAndDayBeforeHoliday_ReturnsZero()
        {
            //Arrange
            var dateStrings = new string[]
            {
                "2013-05-18 06:27:00",
                "2013-06-06 16:27:00",
            };
            var dates = dateStrings.GetDatesFromStrings();
            var vehicle = new Vehicle("Car");

            //Act
            var result = _calculator.GetTax(vehicle, dates);

            //Assert

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(50, "2013-01-02 06:30", "2013-01-02 07:59", "2013-01-02 13:00", "2013-01-02 15:00", "2013-01-02 16:30", "2013-01-02 18:20")]
        [InlineData(50 + 13, "2013-01-02 06:30", "2013-01-02 07:59", "2013-01-02 13:00", "2013-01-02 15:00", "2013-01-02 16:30", "2013-01-02 18:20", "2013-01-07 06:50")]
        public void GetTax_TotalFeeIsGreaterThanMaxDailyFee_ApplyMaxDailyFeeRuleForThisDate(int expectedResult, params string[] dateStrings)
        {
            //Arrange
            var dates = dateStrings.GetDatesFromStrings();
            var vehicle = new Vehicle("Car");

            //Act
            var result = _calculator.GetTax(vehicle, dates);

            //Assert

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(18, "2013-01-02 14:50", "2013-01-02 15:09", "2013-01-02 15:49")]
        [InlineData(26, "2013-09-05 12:50", "2013-09-05 15:20", "2013-09-05 16:19")]
        [InlineData(39, "2013-09-05 12:50", "2013-09-05 15:20", "2013-09-05 16:19", "2013-09-05 17:20")]
        [InlineData(18 + 13, "2013-01-02 14:50", "2013-01-02 15:09", "2013-01-02 15:49", "2013-01-02 17:49")]
        public void GetTax_CheckpointsAreUnderSingleChargeRule_ApplyTaxFeeOnlyOncePerInterval(int expectedResult, params string[] dateStrings)
        {
            //Arrange
            var dates = dateStrings.GetDatesFromStrings();
            var vehicle = new Vehicle("Other");

            //Act
            var result = _calculator.GetTax(vehicle, dates);

            //Assert

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetTax_CheckpointsDuringYear_ReturnsExpectedResult()
        {
            //Arrange
            var vehicle = new Vehicle("Car");

            //Act
            var result = _calculator.GetTax(vehicle, _checkpoints);

            //Assert

            Assert.Equal(79, result);
        }
    }
}
