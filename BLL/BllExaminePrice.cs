using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class BllExaminePrice
    {
        public  bool AddExamine(ExaminePrice examinePrice)
        {
            return ErpServer.AddExamine(examinePrice);
        }

        public  DataTable GetExamineInfo()
        {
            return ErpServer.GetExamineInfo().Tables[0];
        }
    }
}
