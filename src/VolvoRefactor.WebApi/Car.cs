﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoRefactor.WebApi {
    public class Car : Vehicle {
        public String GetVehicleType() {
            return "Car";
            //some update
        }
    }
}