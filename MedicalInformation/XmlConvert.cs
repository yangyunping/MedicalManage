using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Model
{
    public class XmlToConvert
    {
        public static DataTable XmlToDataTable(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据               
                    ds.ReadXml(Xmlrdr);
                    return ds.Tables[0];
                }
                catch
                {
                    return null;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            return null;
        }

        public static string DataTableToXml(DataTable vTable)
        {
            if (null == vTable) return string.Empty;
            StringWriter writer = new StringWriter();
            vTable.WriteXml(writer);
            string xmlstr = writer.ToString();
            writer.Close();
            return xmlstr;

        }
    }
}