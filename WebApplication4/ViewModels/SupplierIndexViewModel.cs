using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class SupplierIndexViewModel
    {
        public IPagedList<Supplier> Suppliers { get; set; } //IPageList
        //public IQueryable<FarmWorker> FarmWorkers { get; set; }
        public string Search { get; set; }
    }
}