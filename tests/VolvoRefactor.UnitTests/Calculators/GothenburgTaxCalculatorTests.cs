using System;
using VolvoRefactor.Application.Models;
using VolvoRefactor.Application.TaxCalculators;
using VolvoRefactor.UnitTests.Utils;
using Xunit;

namespace VolvoRefactor.UnitTests.Calculators
{
    public class GothenburgTaxCalculatorTests
    {
        private readonly GothenburgCongestionTaxCalculator _calculator;
        private readonly DateTime[] _checkpoints;

        public GothenburgTaxCalculatorTests()
        {
            _calculator = new GothenburgCongestionTaxCalculator();
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

        [Theory]
        [InlineData("Motorbike")]
        [InlineData("Military")]
        [InlineData("Emergency")]
        public void GetTax_TollFreeVehicle_ReturnsZero(string vehicleType)
        {
            //Arrange
            var vehicle = new Vehicle(vehicleType);

            //Act
            var result = _calculator.GetTax(vehicle, _checkpoints);

            //Assert

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(13, "Car", "2013-12-04 08:20:00")]
        [InlineData(18, "Car", "2013-12-05 07:28:50")]
        [InlineData(8, "Other", "2013-12-04 18:20:00")]
        [InlineData(0, "Car", "2013-12-04 20:20:00")]
        public void GetTax_NotTollFreeVehicle_ReturnsExpectedResult(int expectedResult, string vehicleType, params string[] dateStrings)
        {
            //Arrange
            var dates = dateStrings.GetDatesFromStrings();
            var vehicle = new Vehicle(vehicleType);

            //Act
            var result = _calculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetTax_UnknownVehicle_ReturnsResultForDefaultType()
        {
            //Arrange
            var type = "UnknownType";
            var dates = _checkpoints[^3..];
            var vehicle = new Vehicle(type);

            //Act
            var result = _calculator.GetTax(vehicle, dates);

            //Assert
            Assert.Equal(8, result);
        }
    }
}
