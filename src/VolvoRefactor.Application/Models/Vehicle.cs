using System;

namespace VolvoRefactor.Application.Models
{
    public class Vehicle
    {
        public enum TransportType
        {
            Car = 0,
            Emergency = 1,
            Diplomat = 2,
            Military = 3,
            Foreign = 4,
            Motorbike = 5
        }
        public TransportType VehicleType { get; init; }
        public Vehicle(string type)
        {
            VehicleType = (TransportType)Enum.Parse(typeof(TransportType), type);
        }
    }
}
