using System;
using System.Collections.Generic;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class TollFreeVehicleRule : BaseTaxRule
    {
        private IList<string> _tollFreeVehicles;

        public TollFreeVehicleRule(IList<string> tollFreeVehicles)
        {
            _tollFreeVehicles = tollFreeVehicles;
        }
        public override void GetTax(DateTime date, Vehicle vehicle, TaxInterval interval, ref int totalFee)
        {
            if (_tollFreeVehicles.Contains(vehicle.VehicleType.ToString()))
            {
                totalFee = 0;
                return;
            }
            NextRule.GetTax(date, vehicle, interval, ref totalFee);
        }
    }
}
