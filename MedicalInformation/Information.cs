using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
            UsePower = new Dictionary<int, string>();
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
        public static Dictionary<int,string> UsePower { get; set; }
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

        public static DataTable ListToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="stringToEncrypt">待加密字符串</param>
        /// <param name="sEncryptionKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string stringToEncrypt, string sEncryptionKey)
        {
            try
            {
                byte[] rgbIV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] rgbKey = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="stringToDecrypt">待解密字符串</param>
        /// <param name="sEncryptionKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            try
            {
                byte[] rgbIV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] rgbKey = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] buffer = Convert.FromBase64String(stringToDecrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
