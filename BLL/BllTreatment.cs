using Model;

namespace BLL
{
    public class BllTreatment
    {
        public bool AddTreatment(Treatment treatment)
        {
            DataClassesDataContext dataClasses = new DataClassesDataContext();
            dataClasses.Treatment.InsertOnSubmit(treatment);
            dataClasses.SubmitChanges();
            return true;
        }
        public bool DeleteTreatment(Treatment treatment)
        {
            DataClassesDataContext dataClasses = new DataClassesDataContext();
            dataClasses.Treatment.DeleteOnSubmit(treatment);
            dataClasses.SubmitChanges();
            return true;
        }
    }
}
