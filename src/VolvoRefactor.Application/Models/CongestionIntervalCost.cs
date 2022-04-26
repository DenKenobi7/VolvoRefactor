using System;
using VolvoRefactor.Application.Helpers;

namespace VolvoRefactor.Application.Models
{
    public class CongestionIntervalCost
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Fee { get; private set; }
        public CongestionIntervalCost(string startTime, string endTime, int fee)
        {
            StartTime = DateHelper.TimeFromString(startTime);
            EndTime = DateHelper.TimeFromString(endTime);
            Fee = fee;
        }
    }
}
