using System;

namespace VolvoRefactor.Application.Models
{
    public class CongestionIntervalCost
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Fee { get; private set; }
        public CongestionIntervalCost(string startTime, string endTime, int fee)
        {
            StartTime = DateTime.ParseExact(startTime, @"HH:mm", null);
            EndTime = DateTime.ParseExact(endTime, @"HH:mm", null);
            Fee = fee;
        }
        public CongestionIntervalCost(DateTime startTime, DateTime endTime, int fee)
        {
            StartTime = startTime;
            EndTime = endTime;
            Fee = fee;
        }
    }
}
