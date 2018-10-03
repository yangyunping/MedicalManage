using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BllPations
    {
        /// <summary>
        /// 新增修改
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="medLog"></param>
        /// <returns></returns>
       public bool InsertOrUpdatePation(Patient patient, MedLog medLog)
        {
            return ErpServer.InsertOrUpdatePation(patient, medLog);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public  DataTable GetPationes(string sKey)
        {
            return ErpServer.GetPationes(sKey).Tables[0];
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public  bool DeletePationes(string key)
        {
            return ErpServer.DeletePationes(key);
        }
    }
}
