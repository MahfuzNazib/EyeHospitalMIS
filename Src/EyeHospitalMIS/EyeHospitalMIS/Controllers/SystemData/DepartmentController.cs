using EyeHospitalMIS.Helpers;
using EysHospitalMIS.BLL.IManager.SystemData;
using EysHospitalMIS.Models.DTO;
using EysHospitalMIS.Models.SystemData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EyeHospitalMIS.Controllers.SystemInfo
{
    public class DepartmentController : Controller
    {
        private readonly string departmentViewPath = "Views/SystemData/Department/";
        private readonly ILogger<DepartmentController> logger;
        private readonly IDepartmentManager departmentManager;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentManager departmentManager)
        {
            this.logger = logger;
            this.departmentManager = departmentManager;
        }

        public IActionResult Index(int Page = 1, int PerPage = 10)
        {
            try
            {
                DataBindModel response = departmentManager.GetAllDepartmentList(Page, PerPage);
                return View(departmentViewPath + "Index.cshtml", response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return View();
            }
        }

        public IActionResult AddDepartment()
        {
            Department department = new Department();
            return PartialView(departmentViewPath + "_Add.cshtml", department);
        }

        public IActionResult CreateDepartment(Department department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView(departmentViewPath + "_Add.cshtml", department);
                }

                departmentManager.CreateDepartment(department);
                var (responseStatus, responseMessage, responseType) = SystemHelper.FormDataSubmitResponse(TempData, "Success", "Department Successfully Created", "success");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return PartialView(departmentViewPath + "_Add.cshtml", department);
            }
        }
    }
}
