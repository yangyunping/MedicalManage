using System;
using System.Data;
using Model;

namespace Model
{
    public sealed class CurrentUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DutyId { get; set; }
        public string DutyName { get; set; }
        public string PhoneNumber { get; set; }
        public string DocAge { get; set; }
        public string PassWord { get; set; }

        public static implicit operator CurrentUser(DataRow drRow)
        {
            return drRow == null
                ? new CurrentUser()
                : new CurrentUser()
                {
                    Id = drRow["DocID"].SafeDbString(),
                    Name = drRow["DocName"].SafeDbString(),
                    Gender = drRow["DocSex"].SafeDbString(),
                    DutyId = drRow["DocDutyID"].SafeDbString(),
                    DutyName = drRow["Name"].SafeDbString(),
                    DocAge = drRow["DocAge"].SafeDbString(),
                    PhoneNumber = drRow["DocTel"].SafeDbString(),
                    PassWord = drRow["DocPassword"].SafeDbString()
                };
        }
    }
}
