using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllPations
    {
       public static  bool InsertPation(Patient patient, MedLog medLog)
        {
            return ErpServer.InsertPation(patient, medLog);
        }
        public static DataTable GetPationes(string sKey)
        {
            return ErpServer.GetPationes(sKey).Tables[0];
        }
    }
}
