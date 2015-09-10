using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWeb.bll;

namespace TaskWeb.ashx
{
    /// <summary>
    /// Task 的摘要说明
    /// </summary>
    public class Task : IHttpHandler
    {
        private TaskBLL taskBll = new TaskBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Params["action"];
            try
            {
                switch (action)
                {
                    case "GetTaskProcessList":
                        {
                            string taskId = context.Request.Params["taskId"] ?? "0";
                            string retjson = taskBll.GetTaskProcessListByTaskId(Convert.ToInt32(taskId));
                            context.Response.Write(retjson);
                            break;
                        }
                    case "GetTask":
                        {
                            string uid = context.Request.Params["uid"] ?? "0";
                            string taskId = context.Request.Params["taskId"] ?? "0";
                            string retjson = taskBll.GetTaskById(Convert.ToInt32(taskId));
                            context.Response.Write(retjson);
                            break;
                        }
                    case "GetMyTask":   //与我有关的任务
                        {
                            string uid = context.Request.Params["uid"] ?? "0";
                            //string retjson = taskBll.GetMySelfTaskList(Convert.ToInt32(uid));
                            string retjson = taskBll.GetMyTaskList(Convert.ToInt32(uid));
                            context.Response.Write(retjson);
                            break;
                        }
                    case "GetMySelfTask":       //我自己创建分配给自己的任务
                        {
                            string uid = context.Request.Params["uid"] ?? "0";
                            //string retjson = taskBll.GetMySelfTaskList(Convert.ToInt32(uid));
                            string retjson = taskBll.GetMyTaskList(Convert.ToInt32(uid));
                            context.Response.Write(retjson);
                            break;
                        }   
                    case "GetMyAssignTask":     //我创建分配给他人的任务
                        {
                            string uid = context.Request.Params["uid"] ?? "0";
                            //string retjson = taskBll.GetMyAssignTaskList(Convert.ToInt32(uid));
                            string retjson = taskBll.GetMyTaskList(Convert.ToInt32(uid));
                            context.Response.Write(retjson);
                            break;
                        }
                    case "GetMyRecvTask":       //我接受他人分配给我的任务
                        {
                            string uid = context.Request.Params["uid"] ?? "0";
                            //string retjson = taskBll.GetMyRecvTaskList(Convert.ToInt32(uid));
                            string retjson = taskBll.GetMyTaskList(Convert.ToInt32(uid));
                            context.Response.Write(retjson);
                            break;
                        }
                    case "GetMyRepeatTask":     //我接受的周期性任务
                        {
                            string uid = context.Request.Params["uid"] ?? "0";
                            //string retjson = taskBll.GetMyRepeatTaskList(Convert.ToInt32(uid));
                            string retjson = taskBll.GetMyTaskList(Convert.ToInt32(uid));
                            context.Response.Write(retjson);
                            break;
                        }
                    case "SaveTask":
                        {                     
                            string json = context.Request.Params["json"];
                            json = JsonUtil.decode(json);                            
                            string retjson = taskBll.SaveTask(json);
                            context.Response.Write(retjson);
                            break;
                        }
                    case "SaveTaskProcess":
                        {
                            string json = context.Request.Params["json"];
                            json = JsonUtil.decode(json);
                            string retjson = taskBll.SaveTaskProcess(json);
                            context.Response.Write(retjson);
                            break;
                        }
                    default:
                        context.Response.Write(JsonUtil.ToJson(new{success = false, content="无权访问！"}));
                        break;
                }
               
            }
            catch (Exception ex)
            {
                context.Response.Write(JsonUtil.ToJson(new { success=false,content=ex.Message}));
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