using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.SystemInfo
{
    public class DepartmentController : Controller
    {
        private readonly string departmentViewPath = "Views/SystemInfo/Department/";
        public IActionResult Index()
        {
            return View(departmentViewPath + "Index.cshtml");
        }
    }
}
