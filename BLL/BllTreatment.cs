using DAL;
using Model;

namespace BLL
{
    public class BllTreatment
    {
        public bool AddTreatment(Treatment treatment)
        {
            return ErpServer.AddTreatment(treatment);
            //using (DataClassesDataContext dataClasses = new DataClassesDataContext())
            //{
            //    dataClasses.Treatment.InsertOnSubmit(treatment);
            //    dataClasses.SubmitChanges();
            //    return true;
            //};
        }
        public bool DeleteTreatment(Treatment treatment)
        {
            return ErpServer.DeleteTreatment(treatment);
            //using (DataClassesDataContext dataClasses = new DataClassesDataContext())
            //{
            //    dataClasses.Treatment.DeleteOnSubmit(treatment);
            //    dataClasses.SubmitChanges();
            //    return true;
            //};
        }
    }
}
