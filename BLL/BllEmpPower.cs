using DAL;
using System.Data;

namespace BLL
{
    public class BllEmpPower
    {
        public  DataTable GetEmpPower(string EmpId)
        {
            return ErpServer.GetEmpPower(EmpId).Tables[0];
        }
    }
}
