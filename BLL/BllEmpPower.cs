using DAL;
using System.Data;

namespace BLL
{
    public class BllEmpPower
    {
        public static DataTable GetEmpPower(string EmpId)
        {
            return ErpServer.GetEmpPower(EmpId).Tables[0];
        }
    }
}
