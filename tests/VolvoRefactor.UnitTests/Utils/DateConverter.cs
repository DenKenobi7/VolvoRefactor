using System;
using System.Linq;

namespace VolvoRefactor.UnitTests.Utils
{
    public static class DateConverter
    {
        public static DateTime[] GetDatesFromStrings(this string[] dates)
        {
            return dates.Select(x => DateTime.Parse(x)).ToArray();
        }
    }
}
