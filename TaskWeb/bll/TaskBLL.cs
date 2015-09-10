using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TaskWeb.bll
{
    public class TaskBLL:BaseBLL
    {
        public static int TYPE_MYSELF = 0;
        public static int TYPE_ASSIGN = 1;
        public static int KIND_ONCE = 0;
        public string SaveTask(string jsonTask) {
            try
            {
                tbTask task = (tbTask)JsonUtil.fromJson(jsonTask, typeof(tbTask));
                
                if (task.id < 1)
                {
                    tbTask t = new tbTask()
                    {
                        content = task.content,
                        name = task.name,
                        startTime = task.startTime,
                        endTime = task.endTime,
                        status = task.status,
                        kind = task.kind,
                        rating = task.rating,
                        addTime = DateTime.Now,
                        type = task.type,
                        points = task.points,
                        creatorId = task.creatorId
                    };                    
                    DB.tbTask.Add(t);
                    foreach (var ta in task.tbTaskAssign)
                    {
                        ta.taskId = task.id;
                        DB.tbTaskAssign.Add(new tbTaskAssign()
                        {
                            taskId = t.id,
                            userId = ta.userId,
                            assignTime = DateTime.Now
                        });
                    }
                    DB.SaveChanges();
                    return JsonUtil.ToJson(new { success = true, content = t.id });
                }
                else
                {
                    var t = DB.tbTask.FirstOrDefault(m => m.id == task.id);
                    t.name = task.name;
                    t.kind = task.kind;
                    t.points = task.points;
                    t.rating = task.rating;
                    t.result = task.result;
                    t.startTime = task.startTime;
                    t.endTime = task.endTime;
                    t.condition = task.condition;
                    t.content = task.content;
                    t.creatorId = task.creatorId;
                    t.status = task.status;
                    t.type = task.type;
                    //选择原来安排的用户
                    var oldUserIds = t.tbTaskAssign.Select(m => m.userId).ToList();
                    //要安排的新用户
                    var newUserIds = task.tbTaskAssign.Select(m => m.userId).ToList();
                    //要删除的用户
                    var delUserIds = oldUserIds.Where(m => !newUserIds.Contains(m));
                    foreach (var uid in delUserIds)
                    {
                        var ta = t.tbTaskAssign.FirstOrDefault(m => m.userId == uid);
                        DB.tbTaskAssign.Remove(ta);
                    }
                    //要新加的用户
                    var addUserIds = newUserIds.Where(m => !oldUserIds.Contains(m));
                    foreach (var uid in addUserIds)
                    {
                        var ta = new tbTaskAssign() { 
                            userId = uid,
                            taskId = t.id,
                            assignTime = DateTime.Now
                        };
                        DB.tbTaskAssign.Add(ta);
                    }
                    DB.SaveChanges();
                    return JsonUtil.ToJson(new { success = true, content = t.id });
                }
                
            }
            catch (Exception ex) {
                return JsonUtil.ToJson(new { success = false, content = ex.Message });
            }
        }

        public string SaveTaskProcess(string json) { 
            try{
                tbTaskProcess tp = (tbTaskProcess)JsonUtil.fromJson(json, typeof(tbTaskProcess));
                if(tp.id<1){
                    tbTaskProcess process = new tbTaskProcess(){
                        title = tp.title,
                        content = tp.content,
                        startTime = tp.startTime,
                        endTime = tp.endTime,
                        userId = tp.userId,
                        taskId = tp.taskId,
                        addTime = tp.addTime
                    };
                    DB.tbTaskProcess.Add(process);
                    DB.SaveChanges();
                    return JsonUtil.ToJson(new { success = true, content = process.id });
                }else{
                    var t = DB.tbTaskProcess.FirstOrDefault(m => m.id == tp.id);
                    t.title = tp.title;
                    t.content = tp.content;
                    t.startTime = tp.startTime;
                    t.endTime = tp.endTime;
                    t.userId = tp.userId;
                    t.taskId = tp.taskId;
                    t.addTime = tp.addTime;
                    DB.SaveChanges();
                    return JsonUtil.ToJson(new { success = true, content = t.id });
                }
                
            }catch(Exception ex){
                return JsonUtil.ToJson(new { success = false, content = ex.Message });
            }
        }

        public string GetTaskById(int taskId) {
            try
            {
                var task = DB.tbTask.FirstOrDefault(m => m.id == taskId);
                string json = JsonUtil.ToCodeJson(task);
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }

        public string GetTaskProcessListByTaskId(int taskId) {
            
            try
            {
                var list = DB.tbTask.FirstOrDefault(m => m.id == taskId).tbTaskProcess;
                string json = JsonUtil.ToCodeJson(list);
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }

        public string GetMyTaskList(int uid)
        {
            try
            {
                var taskList = from t in DB.tbTask
                               join ta in DB.tbTaskAssign
                                   on t.id equals ta.taskId into tt
                               from ta in tt.DefaultIfEmpty()
                               where (t.creatorId == uid || ta.userId == uid )
                               select t;

                string json = JsonUtil.ToCodeJson(taskList);
                string s = taskList.ToString();
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }
        public string GetMySelfTaskList(int uid) {
            try
            {
                var taskList = DB.tbTask.Where(m => m.creatorId == uid && m.type == TYPE_MYSELF && m.kind == KIND_ONCE);
                string json = JsonUtil.ToCodeJson(taskList);
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }

        public string GetMyAssignTaskList(int uid) {
            try
            {
                var taskList = DB.tbTask.Where(m => m.creatorId == uid && m.type == TYPE_ASSIGN && m.kind == KIND_ONCE);
                string json = JsonUtil.ToCodeJson(taskList);
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }

        public string GetMyRecvTaskList(int uid)
        {
            try
            {
                var taskList = DB.tbTaskAssign.Where(m => m.userId == uid && m.tbTask.kind == KIND_ONCE).Select(m => m.tbTask);
                string json = JsonUtil.ToCodeJson(taskList);
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }
        public string GetMyRepeatTaskList(int uid)
        {
            try
            {
                var taskList = from t in DB.tbTask join ta in DB.tbTaskAssign 
                               on t.id equals ta.taskId into tt 
                               from ta in tt.DefaultIfEmpty() 
                               where (t.creatorId == uid || ta.userId ==null) && t.kind!=KIND_ONCE
                               select t;
                
                string json = JsonUtil.ToCodeJson(taskList);
                string s = taskList.ToString();
                return JsonUtil.ToJson(new { success = true, content = json });
            }
            catch (Exception ex)
            {
                return JsonUtil.ToJson(new { success = true, content = ex.Message });
            }
        }
    }
}
