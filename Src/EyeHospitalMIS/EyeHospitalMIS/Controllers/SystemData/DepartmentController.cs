using EysHospitalMIS.Models.SystemData;
using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.SystemInfo
{
    public class DepartmentController : Controller
    {
        private readonly string departmentViewPath = "Views/SystemData/Department/";
        public IActionResult Index()
        {
            return View(departmentViewPath + "Index.cshtml");
        }

        public IActionResult AddDepartment()
        {
            Department department = new Department();
            return PartialView(departmentViewPath + "_Add.cshtml", department);
        }
    }
}
