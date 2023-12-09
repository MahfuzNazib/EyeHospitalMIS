using EyeHospitalMIS.Controllers.SystemInfo;
using EysHospitalMIS.BLL.IManager.SystemData;
using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.BranchManagement
{
    public class BranchManagementController : Controller
    {
        private readonly string branchBaseView = "Views/BranchManagement/";
        private readonly ILogger<BranchManagementController> logger;

        public BranchManagementController(ILogger<BranchManagementController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View(branchBaseView + "Index.cshtml");
        }

        public IActionResult Create()
        {
            return View(branchBaseView + "Create.cshtml");
        }
    }
}
