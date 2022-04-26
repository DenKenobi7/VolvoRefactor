using System.Collections.Generic;

namespace VolvoRefactor.Application.Models
{
    public class CongestionParameters
    {
        public int MaxDailyFee { get; set; }

        public IList<CongestionIntervalCost> CongestionIntervalCosts { get; set; }

        public HolidaysSet HolidaysSet { get; set; }

    }
}
