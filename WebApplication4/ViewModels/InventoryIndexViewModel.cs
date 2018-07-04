using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using System.Web.Mvc;
using PagedList; //adding paging

/// <summary>
/// View Model for Complex Filtering
/// </summary>

namespace WebApplication4.ViewModels
{
    public class InventoryIndexViewModel
    {
        public IPagedList<Inventory> Inventories { get; set; } //IPageList
        //public IQueryable<Inventory> Inventories { get; set; }
        public string Search { get; set; }
        public IEnumerable<InventoryTypesWithCount> InvTypesWithCount { get; set; }
        public string InventoryType { get; set; }

        public IEnumerable<SelectListItem> InvTypeFilterItems
        {
            get
            {
                var allInvTypes = InvTypesWithCount.Select(tc => new SelectListItem
                {
                    Value = tc.InvTypeDescr,
                    Text = tc.InvDescrWithCount
                });

                return allInvTypes;
            }
        }
    }

    //Holds InvType name and number of items within that InvType
    public class InventoryTypesWithCount
    {
        public int InventoryCount { get; set; }
        public string InvTypeDescr { get; set; }
        public string InvDescrWithCount {

            get
            {
                return InvTypeDescr + "(" + InventoryCount.ToString() + ")";
            }
        }
    }
}