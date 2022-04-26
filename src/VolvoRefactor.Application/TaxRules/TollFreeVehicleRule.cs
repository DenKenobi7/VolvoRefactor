using System;
using System.Collections.Generic;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.TaxRules
{
    public class TollFreeVehicleRule : BaseTaxRule
    {
        private IList<string> _tollFreeVehicles;
        private Vehicle _vehicle;

        public TollFreeVehicleRule(IList<string> tollFreeVehicles, Vehicle vehicle)
        {
            _tollFreeVehicles = tollFreeVehicles;
            _vehicle = vehicle;
        }
        public override void GetTax(DateTime date, ref int totalFee)
        {
            if (_tollFreeVehicles.Contains(_vehicle.VehicleType.ToString()))
            {
                totalFee = 0;
                return;
            }
            NextRule.GetTax(date, ref totalFee);
        }
    }
}
