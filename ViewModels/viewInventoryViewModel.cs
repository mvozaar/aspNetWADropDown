using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspNetWADropDown.ViewModels
{
    public class viewInventoryViewModel
    {
        [Display(Name = "Department")]
        public int selectedDepartment { get; set; }
        [Display(Name = "Unit")]
        public int selectedUnit { get; set; }
        public List<string> words { get; set; }
    }
}