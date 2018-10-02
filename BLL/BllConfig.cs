using DAL;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class BllConfig
    {
        public  DataSet GetConfigInfo(int typeID)
        {
            return ErpServer.GetConfigInfo(typeID);
        }
        public IEnumerable<Config> GetConfigStyleInfo()
        {
            DataClassesDataContext dataClasses = new DataClassesDataContext();
            var query = dataClasses.Config.Where(p => p.StyleID == 10000);
            return query.AsEnumerable<Config>();
        }
        public bool AddConfig(Config config)
        {
            DataClassesDataContext dataClasses = new DataClassesDataContext();
            dataClasses.Config.InsertOnSubmit(config);
            dataClasses.SubmitChanges();
            return true;
        }
        public bool DeleteConfig(Config config)
        {
            DataClassesDataContext dataClasses = new DataClassesDataContext();
            dataClasses.Config.DeleteOnSubmit(config);
            dataClasses.SubmitChanges();
            return true;
        }
        
        public bool ModifyConfig(Config config)
        {
            DataClassesDataContext dataClasses = new DataClassesDataContext();
            var info = dataClasses.Config.Where(p => p.SignID == config.SignID).First();
            info.SignID = config.SignID;
            info.Name = config.Name;
            info.StyleID = config.StyleID;
            dataClasses.SubmitChanges();
            return true;
        }
    }
}
