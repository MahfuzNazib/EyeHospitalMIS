﻿using EysHospitalMIS.Models.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.BLL.IManager.SystemData
{
    public interface IDepartmentManager
    {
        public void CreateNewDepartment(Department department);
    }
}