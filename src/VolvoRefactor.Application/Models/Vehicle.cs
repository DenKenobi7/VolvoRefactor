namespace VolvoRefactor.Application.Models
{
    public class Vehicle
    {
        public enum CarType
        {
            Car = 0,
            Emergency = 1,
            Diplomat = 2,
            Military = 3,
            Foreign = 4,
            Motorbike = 5
        }
        public CarType VehicleType { get; init; }
    }
}
