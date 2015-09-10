using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TaskWeb.bll
{    
    
    public class UserBLL:BaseBLL
    {        
        public string Login(string json)
        {
            try
            {
                tbUser user = (tbUser)JsonUtil.fromJson(json, typeof(tbUser));
                string pwd = Md5.GetMD5String(user.userPwd);
                var u = DB.tbUser.FirstOrDefault(m => m.userName == user.userName && m.userPwd == pwd);
                if (u != null)
                {
                    json = JsonUtil.ToCodeJson(u);
                    return JsonUtil.ToJson(new { success = true, content = json });
                }
                else
                {
                    return JsonUtil.ToJson(new { success = false, content = "用户名或密码错误！" });
                }
            }
            catch (Exception ex) {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }

        public string GetUserList()
        {
            try
            {
                var userList = DB.tbUser.ToList();
                string json = JsonUtil.ToCodeJson(userList);
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }


        public void init() {            
            var userList = DB.tbUser.ToList();
            for (int i = 1; i <= 50; i++)
            {
                tbTask t = new tbTask()
                {
                    content = "T" + i,
                    name = "N" + i,
                    startTime = DateTime.Now.AddHours(i*5),
                    endTime = DateTime.Now.AddDays(i*10),
                    status = i % 5,
                    kind = i % (i>20 ? 1:4),
                    rating = i % 4,
                    addTime = DateTime.Now,
                    type = i % 2,
                    points = i * 100,
                    creatorId = userList[i % (userList.Count>2 ?2:userList.Count)].id
                };
                DB.tbTask.Add(t);
                if (t.type == 1) {
                    for (int k = 1; k <= 2; k++) {
                        tbTaskAssign ta = new tbTaskAssign { 
                            taskId = t.id,
                            userId = userList[(i + k) % (userList.Count > 2 ? 2 : userList.Count)].id,
                            assignTime = DateTime.Now.AddDays(i+k)
                        };
                        DB.tbTaskAssign.Add(ta);
                    }
                }
                DB.SaveChanges();
            }
        }
    }
}
