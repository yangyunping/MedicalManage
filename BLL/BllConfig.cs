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
    public class BllConfig
    {
        public static DataSet GetConfigInfo(string configName)
        {
            return ErpServer.GetConfigInfo(configName);
        }  
    }
}
