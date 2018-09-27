using DAL;

namespace BLL
{
    public class Globle
    {
        public static bool TestConnection()
        {
            return ErpServer.TestConnection();
        }
    }
}
