using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using TaskWeb.bll;
using System.Reflection;
using System.Web.Configuration;

namespace TaskWeb.ashx
{
    /// <summary>
    /// AppVersion 的摘要说明
    /// </summary>
    public class Version : IHttpHandler
    {
        private void WriteConfig(string key, string value)
        {            
            //获取Configuration对象
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            //写入<add>元素的Value
            config.AppSettings.Settings[key].Value = value;
            //一定要记得保存，写不带参数的config.Save()也可以
            config.Save(ConfigurationSaveMode.Modified);
            //刷新，否则程序读取的还是之前的值（可能已装入内存）
            ConfigurationManager.RefreshSection("appSettings");
        }
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["action"];
            switch (action)
            {
                case "getVersion":{
                    string code = ConfigurationManager.AppSettings["version"];
                    string url = ConfigurationManager.AppSettings["url"];
                    string appName = ConfigurationManager.AppSettings["appName"];
                    context.Response.ContentType = "text/plain";                    
                    context.Response.Write(JsonUtil.ToJson(new {  success = true,  version = code,
                                                                    url = url, appName = appName  }));
                    break;
                }
                case "setVersion":
                    WriteConfig("version", "1.01");
                    context.Response.Write(JsonUtil.ToJson(new { success = false, content = "ok！" }));
                    break;
                default:{
                    context.Response.Write(JsonUtil.ToJson(new {  success = false,  content = "无权访问！"  }));
                    break;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}