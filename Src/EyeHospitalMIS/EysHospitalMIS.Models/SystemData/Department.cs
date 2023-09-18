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

        [Required]
        public string NAME { get; set; } = "";

        [Required]
        public string SHORT_NAME { get; set; } = "";

        public string DEPARTMENT_ICON { get; set; }

        public int STATUS { get; set; } = 1; // By Default STATUS is 1. That Means Its Active.
    }
}
