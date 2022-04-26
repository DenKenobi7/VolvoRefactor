using System;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class HolidayRule : BaseTaxRule
    {
        private HolidaysSet _holidaysSet;
        public HolidayRule(HolidaysSet holidaysSet)
        {
            _holidaysSet = holidaysSet;
        }
        public override void GetTax(DateTime date, ref int totalFee)
        {
            if (IsTaxFreeMonth(date) ||
                IsTaxFreeDayOfWeek(date) ||
                IsTaxFreeHolidayOrDayBeforeHoliday(date))
            {
                totalFee = 0;
                return;
            }
            NextRule.GetTax(date, ref totalFee);
        }
        private bool IsTaxFreeMonth(DateTime date) => _holidaysSet.Months.Contains(date.Month);
        private bool IsTaxFreeDayOfWeek(DateTime date) => _holidaysSet.DaysOfWeek.Contains(date.DayOfWeek.ToString());
        private bool IsTaxFreeHolidayOrDayBeforeHoliday(DateTime date)
        {
            return _holidaysSet.HolidayDates.Contains(date) ||
                   _holidaysSet.HolidayDates.Contains(date.AddDays(1));
        }
    }
}
