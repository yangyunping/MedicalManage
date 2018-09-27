using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Medicine
    {
        /// <summary>
        /// 药品信息
        /// </summary>
        public string MedId { get; set; } //ID
        public string MedName { get; set; }//名字
        public string MedTypeId { get; set; }//类别
        public string MedUnit { get; set; }//单位
        public string MedStandard { get; set; }//标准
        public string MedApproval { get; set; }//批准文号
        public string MedSpellFirst { get; set; }//首拼


        public static implicit operator Medicine(DataRow drRow)
        {
            return drRow == null
                ? new Medicine()
                : new Medicine()
                {
                    MedId = drRow["MedID"].SafeDbString(),
                    MedName = drRow["MedName"].SafeDbString(),
                    MedTypeId = drRow["MedTypeID"].SafeDbString(),
                    MedUnit = drRow["MedUnit"].SafeDbString(),
                    MedStandard = drRow["MedStandard"].SafeDbString(),
                    MedApproval = drRow["MedApproval"].SafeDbString(),
                    MedSpellFirst = drRow["MedSpellFirst"].SafeDbString()
                };
        }
    }
}
