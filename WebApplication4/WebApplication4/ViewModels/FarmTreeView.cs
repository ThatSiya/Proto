using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class FarmTreeView
    {
        public Farm Farm { get; set; }
        public Land Land { get; set; }
        public Field Field { get; set; }
        public IEnumerable<Farm> IFarm { get; set; }
        public IEnumerable<Land> ILand { get; set; }
        public IEnumerable<Field> IField { get; set; }
    }
}