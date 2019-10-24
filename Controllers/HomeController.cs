using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspNetWADropDown.Models;
using aspNetWADropDown.ViewModels;

namespace aspNetWADropDown.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DropDownBox()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DropDownBoxEF()
        {
            vozikEntities vozik = new vozikEntities();
            ViewBag.Departments = new SelectList(vozik.Departments, "Id", "Label");

            return View();
        }
        public ActionResult DropDownBoxWA(int? dept = 0)
        {
            ViewBag.dept = dept;

            viewInventoryViewModel viewModel = new viewInventoryViewModel
            {
                selectedDepartment = ViewBag.dept
            };

            vozikEntities vozik = new vozikEntities();
            ViewBag.Departments = new SelectList(
                vozik.Departments.Select(d => new { Value = d.id,
                    Text = d.Label
                })
                .AsEnumerable(), "Value", "Text","Selected");

            return View(viewModel);
        }
    }
}