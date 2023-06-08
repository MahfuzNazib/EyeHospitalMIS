using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.SystemInfo
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
