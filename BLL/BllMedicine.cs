using DAL;
using Model;

namespace BLL
{
    public class BllMedicine
    {
        public static bool InsertMedicine(Medicine medicine)
        {
            return ErpServer.InsertMedicine(medicine);
        }

        public static bool InsertInMed(AddMedicine addMedicine)
        { 
            return ErpServer.InsertInMed(addMedicine);
        }
    }
}
