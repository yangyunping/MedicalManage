using System.Text;

namespace Model
{
    public class CallWebPage
    {
        /// <summary>
        /// 访问URL地址，返回值
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpTimeout"></param>
        /// <param name="postEncoding"></param>
        /// <returns></returns>
        public static string CallWeb(string url, int httpTimeout, Encoding postEncoding)
        {
            string rStr = "";
            System.Net.WebRequest req = null;
            System.Net.WebResponse resp = null;
            System.IO.Stream os = null;
            System.IO.StreamReader sr = null;
            try
            {
                //创建连接
                req = System.Net.WebRequest.Create(url);
                req.ContentType = "application/x-www-form-urlencoded";
                req.Method = "GET";
                //时间
                if (httpTimeout > 0)
                {
                    req.Timeout = httpTimeout;
                }
                //读取返回结果
                resp = req.GetResponse();
                sr = new System.IO.StreamReader(resp.GetResponseStream(), postEncoding);
                rStr = sr.ReadToEnd();
                int bodystart = rStr.IndexOf("<body>") + 6; //除去<body>
                int bodylenght = rStr.LastIndexOf("</body>") - bodystart; //除去</body>
                rStr = rStr.Substring(bodystart, bodylenght).Trim(); //除去空格
            }
            catch
            {
                return rStr;
            }
            finally
            {
                //关闭资源
                if (os != null)
                {
                    os.Dispose();
                    os.Close();
                }
                if (sr != null)
                {
                    sr.Dispose();
                    sr.Close();
                }
                if (resp != null)
                {
                    resp.Close();
                }
                if (req != null)
                {
                    req.Abort();
                    req = null;
                }
            }
            return rStr;
        }
    }
}
