using EysHospitalMIS.Models.SecurityManager.Module;
using EysHospitalMIS.Models.SecurityManager.SubModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.ViewModel.SecurityManager
{
    public class SideBarView
    {
        List<Module> Modules { get; set; }
        List<SubModule> SubModules { get; set; }
    }
}
