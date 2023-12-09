using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.Models.SecurityManager.User
{
    public class User
    {
        public int ID { get; set; }
        public string DISPLAY_NUMBER { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set;}
        public string FULL_NAME { get; set; }
        public string EMAIL { get; set; }
        public string CONTACT_NO { get; set; }
        public int DESIGNATION_ID { get; set; }
        public int BRANCH_ID { get; set; }
        public int IS_ACTIVE { get; set; }
        public string STATUS { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public int IS_TEMP_PASSWORD { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public int UPDATED_BY { get; set; }
    }
}
