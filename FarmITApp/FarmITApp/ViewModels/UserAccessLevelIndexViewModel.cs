using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmITApp.Models;
using PagedList;
using System.Web.Mvc;

namespace FarmITApp.ViewModels
{
    public class UserAccessLevelIndexViewModel
    {
        public IPagedList<UserAccessLevel> UserAccessLevels { get; set; }
        public string Search { get; set; }
    }
}