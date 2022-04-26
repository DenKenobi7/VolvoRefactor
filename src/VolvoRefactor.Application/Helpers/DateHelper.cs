using System;

namespace VolvoRefactor.Application.Helpers
{
    public static class DateHelper
    {
        public static DateTime DateFromString(string input)
        {
            return DateTime.ParseExact(input, @"dd.MM", null);
        }
    }
}
