using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using FarmITApp.Models;

namespace FarmITApp.ViewModels
{
    public class SupplierIndexViewModel
    {
        public IPagedList<Supplier> Suppliers { get; set; } //IPageList
        public string Search { get; set; }
        public string SupplierName { get; set; }
    }
}