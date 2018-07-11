using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using PagedList;
using System.Web.Mvc;

namespace WebApplication4.ViewModels
{
    public class UserAccessLevelIndexViewModel
    {
        public IPagedList<UserAccessLevel> UserAccessLevels { get; set; }
        public string Search { get; set; }
    }
}