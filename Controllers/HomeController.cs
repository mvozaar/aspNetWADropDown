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
        public ActionResult DropDownBoxWA(int? dept = 0, int? unit = 0)
        {
            ViewBag.dept = dept;
            ViewBag.unit = unit;

            viewInventoryViewModel viewModel = new viewInventoryViewModel
            {
                selectedDepartment = ViewBag.dept,
                selectedUnit = ViewBag.unit
            };

            vozikEntities vozik = new vozikEntities();
            ViewBag.Departments = new SelectList(
                vozik.Departments.Select(d =>
                new {
                    Value = d.id,
                    Text = d.Label
                })
                .AsEnumerable(), "Value", "Text","Selected");

            ViewBag.Units = new SelectList(
                vozik.Units.Select(d =>
                new {
                    Value = d.id,
                    Text = d.Label
                })
                .AsEnumerable(), "Value", "Text", "Selected");

            return View(viewModel);
        }

        public ActionResult DropDownBoxMVVM(int? dept = 0, int? unit = 0)
        {
            ViewBag.dept = dept;
            ViewBag.unit = unit;

            viewInventoryViewModel viewModel = new viewInventoryViewModel
            {
                selectedDepartment = ViewBag.dept,
                selectedUnit = ViewBag.unit,
                words = new List<string> { "Hello", "Partial","World","With", "Model"}
            };

            vozikEntities vozik = new vozikEntities();
            ViewBag.Departments = new SelectList(
                vozik.Departments.Select(d =>
                new {
                    Value = d.id,
                    Text = d.Label
                })
                .AsEnumerable(), "Value", "Text", "Selected");

            ViewBag.Units = new SelectList(
                vozik.Units.Select(d =>
                new {
                    Value = d.id,
                    Text = d.Label
                })
                .AsEnumerable(), "Value", "Text", "Selected");

            return View(viewModel);
        }

        public ActionResult ShowPartial(int dept = -1, int unit = -1)
        {
            viewInventoryViewModel viewModel = new viewInventoryViewModel
            {
                selectedDepartment = dept,
                selectedUnit = unit,
                words = new List<string> { "Hello", "Partial", "World", "With", "Model" }
            };

            return PartialView(viewModel);
        }
        [HttpGet]
        public ActionResult GetUnits(int dept)
        {
            if (dept>0)
            {
//                var repo = new RegionsRepository();
                vozikEntities vozik = new vozikEntities();

                IEnumerable<SelectListItem> units = vozik.Units
                    .Where(n => n.DepartmentId == dept)
                    .Select(n =>
                           new SelectListItem
                           {
                               Value = n.id.ToString(),
                               Text = n.Label
                           })
                    .ToArray(); //GetRegions(iso3);
                return Json(units, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}