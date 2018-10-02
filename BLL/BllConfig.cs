using DAL;
using System.Data;

namespace BLL
{
    public class BllConfig
    {
        public static DataSet GetConfigInfo(int typeID)
        {
            return ErpServer.GetConfigInfo(typeID);
        }  
    }
}
