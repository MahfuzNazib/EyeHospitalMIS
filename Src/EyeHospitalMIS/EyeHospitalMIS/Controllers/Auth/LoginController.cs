using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.Auth
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Auth/SignIn.cshtml");
        }
    }
}
