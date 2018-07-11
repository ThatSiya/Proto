using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using WebApplication4.Models;
using System.Web.Mvc;

namespace WebApplication4.ViewModels
{
    public class CustomerIndexViewModel
    {
        public IPagedList<Customer> Customers { get; set; } //IPageList
        //public IQueryable<Customer> Customers { get; set; }
        public string Search { get; set; }   
    }
}