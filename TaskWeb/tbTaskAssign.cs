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
    
    public partial class tbTaskAssign
    {
        public int id { get; set; }
        public int taskId { get; set; }
        public int userId { get; set; }
        public System.DateTime assignTime { get; set; }

        [JsonIgnore]
        public virtual tbTask tbTask { get; set; }
        [JsonIgnore]
        public virtual tbUser tbUser { get; set; }
    }
}
