using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllEmployee
    {
        public static DataSet GetEmployeeInfo(string empId)
        {
            return ErpServer.GetEmployeeInfo($@" and DocID ='{empId}'");
        }
    }
}
