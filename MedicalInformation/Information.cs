using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
        /// <summary>
        /// 病人ID
        /// </summary>
        public static string PatId { set; get; }
        /// <summary>
        /// 写配置文件
        /// </summary>
        /// <param name="section">存放名称</param>
        /// <param name="key">存放KEY</param>
        /// <param name="value">存放的路径</param>
        /// <param name="filePath">配置文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        /// <summary>
        /// 读配置文件
        /// </summary>
        /// <param name="section">读取的名称</param>
        /// <param name="key">读取KEY</param>
        /// <param name="def"></param>
        /// <param name="value">读取路径</param>
        /// <param name="size"></param>
        /// <param name="filePath">配置文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder value, int size, string filePath);
    }
}
