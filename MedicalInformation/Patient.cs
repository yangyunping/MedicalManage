using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 病人信息
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// ID
        /// </summary>
        public string PatID { set; get; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PatName { set; get; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age { set; get; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { set; get; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string TelPhone { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Addresses { set; get; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public string IsDelete { set; get; }
    }
}
