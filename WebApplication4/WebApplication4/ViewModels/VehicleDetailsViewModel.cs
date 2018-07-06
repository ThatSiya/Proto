using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    //Contains properties to be displayed in the details view
    public class VehicleDetailsViewModel
    {
        public Vehicle vehicles { get; set; }
        public VehicleService vehicleServices { get; set; }
    }
}