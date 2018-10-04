using DAL;
using System.Data;

namespace BLL
{
    public class BllEmployee
    {
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public  DataTable GetEmployeeInfo(string key)
        {
            string sSql = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                sSql +=$@" and (DocName like '%{key}%' or DocID like '%{key}%')";
            }
            return ErpServer.GetEmployeeInfo(sSql).Tables[0];
        }
    }
}
