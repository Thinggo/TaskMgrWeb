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
    
    public partial class tbButton
    {
        public tbButton()
        {
            this.tbRoleMenuButton = new HashSet<tbRoleMenuButton>();
            this.tbMenu = new HashSet<tbMenu>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string icon { get; set; }
        public Nullable<int> sort { get; set; }
        public System.DateTime addDate { get; set; }
        public string description { get; set; }

        [JsonIgnore]
        public virtual ICollection<tbRoleMenuButton> tbRoleMenuButton { get; set; }
        [JsonIgnore]
        public virtual ICollection<tbMenu> tbMenu { get; set; }
    }
}
