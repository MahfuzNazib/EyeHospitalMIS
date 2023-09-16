using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EysHospitalMIS.DAL.Data
{
    public interface IDbContext
    {
        public void ExecuteQuery(string query, List<param> @params);
    }
}
