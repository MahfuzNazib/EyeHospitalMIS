﻿using EysHospitalMIS.BLL.IManager.SystemData;
using EysHospitalMIS.Models.SystemData;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            try
            {

            }
            catch (Exception ex)
            {
                
            }
            return View(departmentViewPath + "Index.cshtml");
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
                //if(!ModelState.IsValid)
                //{
                //    return PartialView(departmentViewPath + "_Add.cshtml", department);
                //}

                departmentManager.CreateDepartment(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
