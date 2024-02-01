using Microsoft.AspNetCore.Mvc;
using EysHospitalMIS.Models.Auth;

namespace EyeHospitalMIS.Controllers.Auth
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Auth/SignIn.cshtml");
        }

        public IActionResult DoLogin(UserLogin userLogin)
        {
            string userName = userLogin.UserName;
            string password = userLogin.Password;   

            if(userName == password)
            {
                return RedirectToAction ("Index", "Home");
            }
            return View("Views/Auth/SignIn.cshtml");
        }
    }
}
