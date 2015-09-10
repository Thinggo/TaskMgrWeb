using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using TaskWeb.bll;

namespace TaskWeb.ashx
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler
    {
        private UserBLL bll = new UserBLL();


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];

            try
            {
                switch (action)
                {
                    case "UploadImage": {
                        context.Response.ContentType = "text/plain";
                        
                        string userName = context.Request.Params["userName"];
                        if (string.IsNullOrEmpty(userName)) {
                            context.Response.Write(JsonUtil.ToJson(new { success = false, content = "参数错误！" }));
                            return;
                        }
                        HttpPostedFile f1 = context.Request.Files["image_head_file"];
                        String fileExt = System.IO.Path.GetExtension(f1.FileName);
                        f1.SaveAs(context.Server.MapPath("~/download/") + userName + fileExt);
                        
                        System.Drawing.Image image = System.Drawing.Image.FromStream(f1.InputStream);
                        int newWidth = 150, newHeight = 150;
                        if ((decimal)image.Width / image.Height > (decimal)newWidth / newHeight)
                        {
                            newHeight = Convert.ToInt32((decimal)image.Height * newWidth / image.Width);
                        }
                        else if ((decimal)image.Width / image.Height < (decimal)newWidth / newHeight)
                        {
                            newWidth = Convert.ToInt32((decimal)image.Width * newHeight / image.Height);
                        }
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(newWidth, newHeight);
                        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
                        g.DrawImage(image, rectDestination, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
                        bmp.Save(context.Server.MapPath("~/download/") + userName + DateTime.Now.ToString("yyyyMMddHHmmss") + fileExt);
                        bmp.Dispose();
                        image.Dispose();
                        context.Response.Write(JsonUtil.ToJson(new { success = true, content = "上传成功！" }));
                        break;
                    }
                    case "Login":
                        {
                            string json = context.Request.Params["json"];
                            json = JsonUtil.decode(json);
                            json = bll.Login(json);
                            context.Response.Write(json);
                            break;
                        }
                    case "GetUserList":
                        {
                            string json = bll.GetUserList();
                            context.Response.Write(json);
                            break;
                        }
                    default:
                        {
                            context.Response.Write(JsonUtil.ToJson(new { success = false, content="无权访问！"}));
                            break;
                        }
                }

            }
            catch (Exception e)
            {
                context.Response.Write(JsonUtil.ToJson(new { success = false, content = e.Message }));
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