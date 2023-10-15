using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SystemData
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Department Name Can't be Empty")]
        public string? NAME { get; set; }

        [Required(ErrorMessage = "Department Short Name Can't be Empty")]
        public string? SHORT_NAME { get; set; }
        public string? DEPARTMENT_ICON { get; set; }
        public int STATUS { get; set; } // By Default STATUS is 1. That Means Its Active.
        public int TOTAL_COUNT { get; set; }
    }
}
