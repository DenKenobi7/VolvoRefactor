using System;
using System.Collections.Generic;

namespace VolvoRefactor.WebApi.DTOs
{
    public class CongestionTaxDTO
    {
        public string VehicleType { get; set; }
        public string City { get; set; }
        public DateTime[] Dates { get; set; }
    }
}
