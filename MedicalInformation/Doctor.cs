using System;
using System.Data;
using Model;

namespace Model
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public sealed class Doctor
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 职务ID
        /// </summary>
        public string DutyId { get; set; }
        /// <summary>
        /// 职务名称
        /// </summary>
        public string DutyName { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 医生年龄
        /// </summary>
        public string DocAge { get; set; }
        /// <summary>
        ///密码
        /// </summary>
        public string PassWord { get; set; }

        public static implicit operator Doctor(DataRow drRow)
        {
            return drRow == null
                ? new Doctor()
                : new Doctor()
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
