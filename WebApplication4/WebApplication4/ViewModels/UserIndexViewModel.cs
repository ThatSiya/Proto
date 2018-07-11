using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using WebApplication4.Models;
using System.Web.Mvc;

namespace WebApplication4.ViewModels
{
    public class UserIndexViewModel
    {
        public IPagedList<User> Users { get; set; }
        public string Search { get; set; }
    }
}