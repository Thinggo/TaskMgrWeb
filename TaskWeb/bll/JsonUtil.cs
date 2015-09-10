using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace TaskWeb.bll
{
    public class JsonUtil
    {

        public static string ToJson(object obj) {
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            s.NullValueHandling = NullValueHandling.Ignore;
            string json = JsonConvert.SerializeObject(obj, Formatting.None, s);
            return json;
        }
       
        public static object fromJson(string json, Type type) {
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            s.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject(json, type, s);
        }
        public static object fromCodeJson(string json, Type type)
        {
            string str = decode(json);
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            s.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject(str, type, s);
        }
        public static string ToCodeJson(object obj)
        {
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            s.NullValueHandling = NullValueHandling.Ignore;
            string json = JsonConvert.SerializeObject(obj, Formatting.None, s);
            return code(json);
        }

        public static string code(string str) {
            if (string.IsNullOrEmpty(str))
                return null;
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        public static string decode(string str)
        {
            if(string.IsNullOrEmpty(str))
                return null;
            byte[] outputb = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(outputb);
        }
    }
}
