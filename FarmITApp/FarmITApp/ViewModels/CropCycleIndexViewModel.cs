using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmITApp.Models;
using PagedList;

namespace FarmITApp.ViewModels
{
    public class CropCycleIndexViewModel
    {
        // public IEnumerable<CropCycle> CropCycles { get; set; }
        public IPagedList<CropCycle> CropCycles { get; set; }
        public string Search { get; set; }
    }
}