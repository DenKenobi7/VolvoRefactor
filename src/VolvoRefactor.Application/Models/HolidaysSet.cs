using System;
using System.Collections.Generic;

namespace VolvoRefactor.Application.Models
{
    public class HolidaysSet
    {
        public List<string> DaysOfWeek { get; init; }
        public List<DateTime> HolidayDates { get; init; }
        public List<int> Months { get; init; }
    }
}
