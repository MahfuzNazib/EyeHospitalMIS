using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.SystemInfo
{
    public class BloodGroupController : Controller
    {
        private string bloodGroupViewPath = "Views/SystemInfo/BloodGroup/";
        
        public IActionResult Index()
        {
            return View(bloodGroupViewPath+"Index.cshtml");
        }
    }
}
