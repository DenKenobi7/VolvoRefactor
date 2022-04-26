using System.Collections.Generic;

namespace VolvoRefactor.Application.Models
{
    public class CongestionConfiguration
    {
        public string City { get; set; }
        public int MaxDailyFee { get; set; }

        public IList<string> TollFreeVehicles { get; set; }

        public IList<CongestionIntervalCost> CongestionIntervalCosts { get; set; }

        public HolidaysSet HolidaysSet { get; set; }

    }
}
