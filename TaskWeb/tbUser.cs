//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskWeb
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public partial class tbUser
    {
        public tbUser()
        {
            this.tbLoginLog = new HashSet<tbLoginLog>();
            this.tbSales = new HashSet<tbSales>();
            this.tbTask = new HashSet<tbTask>();
            this.tbTaskAssign = new HashSet<tbTaskAssign>();
            this.tbTaskProcess = new HashSet<tbTaskProcess>();
            this.tbDepartment = new HashSet<tbDepartment>();
            this.tbRole = new HashSet<tbRole>();
        }
    
        public int id { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public string realName { get; set; }
        public bool status { get; set; }
        public Nullable<int> points { get; set; }
        public string tel { get; set; }
        public Nullable<int> grade { get; set; }
        public string description { get; set; }
        public System.DateTime addDate { get; set; }

        [JsonIgnore]
        public virtual tbBug tbBug { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbLoginLog> tbLoginLog { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbSales> tbSales { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbTask> tbTask { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbTaskAssign> tbTaskAssign { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbTaskProcess> tbTaskProcess { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbDepartment> tbDepartment { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbRole> tbRole { get; set; }
    }
}
