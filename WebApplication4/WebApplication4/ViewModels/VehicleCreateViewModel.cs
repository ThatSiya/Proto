using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class VehicleCreateViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Unit Unit { get; set; }     
    }
}