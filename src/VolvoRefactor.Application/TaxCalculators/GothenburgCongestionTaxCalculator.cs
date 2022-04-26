using System.Collections.Generic;
using VolvoRefactor.Application.Helpers;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxCalculators
{
    internal class GothenburgCongestionTaxCalculator : CongestionTaxCalculator
    {
        public GothenburgCongestionTaxCalculator()
        {
            City = "Gothenburg";
            CongestionParameters = new CongestionParameters
            {
                MaxDailyFee = 60,
                CongestionIntervalCosts = new List<CongestionIntervalCost>()
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
                        DateHelper.DateFromString("01.01"),
                        DateHelper.DateFromString("06.01"),
                        DateHelper.DateFromString("29.03"),
                        DateHelper.DateFromString("31.03"),
                        DateHelper.DateFromString("01.04"),
                        DateHelper.DateFromString("01.05"),
                        DateHelper.DateFromString("09.05"),
                        DateHelper.DateFromString("19.05"),
                        DateHelper.DateFromString("06.06"),
                        DateHelper.DateFromString("22.06"),
                        DateHelper.DateFromString("02.11"),
                        DateHelper.DateFromString("24.12"),
                        DateHelper.DateFromString("25.12"),
                        DateHelper.DateFromString("26.12"),
                        DateHelper.DateFromString("31.12"),
                    }
                }
            };
        }

    }
}
