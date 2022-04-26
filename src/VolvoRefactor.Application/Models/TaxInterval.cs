using System;

namespace VolvoRefactor.Application.Models
{
    internal class TaxInterval
    {
        public TaxInterval(string startTime, string endTime, int maxFee)
        {
            StartTime = DateTime.Parse(startTime);
            EndTime = DateTime.Parse(endTime);
            MaxFee = maxFee;
        }
        public TaxInterval(DateTime startTime, DateTime endTime, int maxFee)
        {
            StartTime = startTime;
            EndTime = endTime;
            MaxFee = maxFee;
        }

        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int MaxFee { get; private set; }
    }
}
