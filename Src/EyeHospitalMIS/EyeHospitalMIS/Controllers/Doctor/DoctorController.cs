using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.Doctor
{
    public class DoctorController : Controller
    {
        private readonly string doctorViewPath = "Views/Doctor/";
        public IActionResult Index()
        {
            return View(doctorViewPath + "Index.cshtml");
        }

        public IActionResult AddDoctor()
        {
            return View(doctorViewPath + "Add.cshtml");
        }
    }
}
