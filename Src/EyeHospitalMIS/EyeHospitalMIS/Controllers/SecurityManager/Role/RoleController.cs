using EysHospitalMIS.BLL.IManager.SecurityManager;
using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SecurityManager.Role;
using Microsoft.AspNetCore.Mvc;

namespace EyeHospitalMIS.Controllers.SecurityManager.Role
{
    public class RoleController : Controller
    {
        private readonly string roleViewPath = "Views/SecurityManager/Role/";
        private readonly ILogger<RoleController> logger;    
        private readonly IRoleManager roleManager;

        public RoleController(ILogger<RoleController> logger, IRoleManager roleManager)
        {
            this.logger = logger;
            this.roleManager = roleManager;
        }

        public IActionResult Index(int Page = 1, int PerPage = 10)
        {
            try
            {
                DataBindModel roles = roleManager.GetAllRoles(Page, PerPage);
                return View(roleViewPath + "/Index.cshtml", roles);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        public IActionResult Create()
        {
            try
            {
                List<RolePermission> permissions = new List<RolePermission>();
                permissions = roleManager.GetAllRolePermission();
                return View(roleViewPath + "/Create.cshtml", permissions);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        public IActionResult SaveNewRole(RolePermissionRequest rolePermissionRequest)
        {
            return View();
        }
    }
}
