using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public class MedLog
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ID { set; get; }
        /// <summary>
        /// 操作类别
        /// </summary>
        public string OperType { set; get; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Notes { set; get; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateTime { set; get; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public string OperateEmpID { set; get; }
    }
}
