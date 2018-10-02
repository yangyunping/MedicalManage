using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class Information
    {
        static Information()
        {
            CurrentUser = new Doctor();
            Medicine = new Medicine();
            UsePower = new Dictionary<string, string>();
        }
        /// <summary>
        /// 员工
        /// </summary>
        public static Doctor CurrentUser { get; set; }

        /// <summary>
        /// 药品
        /// </summary>
        public static Medicine Medicine { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public static Dictionary<string,string> UsePower { get; set; }
        /// <summary>
        /// 复制方案信息
        /// </summary>
        public static DataTable CopyPlanInfo { set; get; }

        public static string PatId { set; get; }
    }
}
