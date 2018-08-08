using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using FarmITApp.Models;
using System.Web.Mvc;

namespace FarmITApp.ViewModels
{
    public class UserIndexViewModel
    {
        public IPagedList<User> Users { get; set; }
        public string Search { get; set; }
    }
}