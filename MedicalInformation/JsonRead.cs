using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MedicalInformation
{
    public class JsonRead
    {
        public  Weather JsonReadInfo(string json)
        {
            JObject jObject = JObject.Parse(json);
            Weather weather = new Weather()
            {
                city = jObject["weatherinfo"]["city"].ToString(),
                cityid = jObject["weatherinfo"]["cityid"].ToString(),
                temp1 = jObject["weatherinfo"]["temp1"].ToString(),
                temp2 = jObject["weatherinfo"]["temp2"].ToString(),
                weather = jObject["weatherinfo"]["weather"].ToString(),
                img1 = jObject["weatherinfo"]["img1"].ToString(),
                img2 = jObject["weatherinfo"]["img2"].ToString(),
                ptime = jObject["weatherinfo"]["img2"].ToString()
            };
            return weather;
        }
        /// <summary>
        /// Json 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        /// <summary>
        /// Json 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public  T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }

   
    public class Weather
    {
        public string city { set; get; }
        public string cityid { set; get; }
        public string temp1 { set; get; }
        public string temp2{ set; get; }
        public string weather { set; get; }
        public string img1 { set; get; }
        public string img2 { set; get; }
        public string ptime { set; get; }
    }
}
