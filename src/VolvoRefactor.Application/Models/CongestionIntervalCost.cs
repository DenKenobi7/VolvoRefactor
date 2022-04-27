using System;
using VolvoRefactor.Application.Helpers;

namespace VolvoRefactor.Application.Models
{
    public class CongestionIntervalCost
    {
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public int Fee { get; init; }
        public CongestionIntervalCost(string startTime, string endTime, int fee)
        {
            StartTime = DateHelper.TimeFromString(startTime);
            EndTime = DateHelper.TimeFromString(endTime);
            Fee = fee;
        }
        public CongestionIntervalCost() { }
    }
}
