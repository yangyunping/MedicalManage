using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    /// <summary>
    /// 药品信息
    /// </summary>
    public class Medicine
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string MedId { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string MedName { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string MedTypeId { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string MedUnit { get; set; }
        /// <summary>
        /// 标准
        /// </summary>
        public string MedStandard { get; set; }
        /// <summary>
        /// 批准文号
        /// </summary>
        public string MedApproval { get; set; }
        /// <summary>
        /// 首拼
        /// </summary>
        public string MedSpellFirst { get; set; }

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
