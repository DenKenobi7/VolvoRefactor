using System;

namespace VolvoRefactor.Application.Models
{
    public class Vehicle
    {
        public enum TransportType
        {
            Other = 0,
            Car = 1,
            Emergency = 1,
            Diplomat = 3,
            Military = 4,
            Foreign = 5,
            Motorbike = 6
        }
        public TransportType VehicleType { get; init; }
        public Vehicle(string type)
        {
            VehicleType = Enum.TryParse(type, out TransportType vehicleType) 
                ? vehicleType 
                : TransportType.Other;             
        }
    }
}
