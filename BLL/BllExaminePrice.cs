using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BllExaminePrice
    {
        public static bool AddExamine(ExaminePrice examinePrice)
        {
            return ErpServer.AddExamine(examinePrice);
        }

        public static DataTable GetExamineInfo()
        {
            return ErpServer.GetExamineInfo().Tables[0];
        }
    }
}
