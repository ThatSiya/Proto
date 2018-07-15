using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ReportController : Controller
    {
        FarmDbContext db = new FarmDbContext();
        // GET: Report
        public ActionResult Index()
        {
            ViewBag.FarmID = new SelectList(db.Farms, "FarmID", "FarmName");
            ReportViewer reportViewer = new ReportViewer();
            ViewBag.ReportViewer = reportViewer;

            return View();
        }
        private ReportParameter[] GetParametersServer()
        {
            ReportParameter p1 = new ReportParameter("ShowBingMaps", "Visible");
            ReportParameter p2 = new ReportParameter("ShowAll", "True");
            return new ReportParameter[] { p1, p2 };
        }
    }
}