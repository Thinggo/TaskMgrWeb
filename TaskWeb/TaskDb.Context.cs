﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TaskDbEntities : DbContext
    {
        public TaskDbEntities()
            : base("name=TaskDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbBug> tbBug { get; set; }
        public DbSet<tbButton> tbButton { get; set; }
        public DbSet<tbDepartment> tbDepartment { get; set; }
        public DbSet<tbGoods> tbGoods { get; set; }
        public DbSet<tbGrades> tbGrades { get; set; }
        public DbSet<tbLoginLog> tbLoginLog { get; set; }
        public DbSet<tbMenu> tbMenu { get; set; }
        public DbSet<tbRole> tbRole { get; set; }
        public DbSet<tbRoleMenuButton> tbRoleMenuButton { get; set; }
        public DbSet<tbSales> tbSales { get; set; }
        public DbSet<tbTask> tbTask { get; set; }
        public DbSet<tbTaskAssign> tbTaskAssign { get; set; }
        public DbSet<tbTaskProcess> tbTaskProcess { get; set; }
        public DbSet<tbUser> tbUser { get; set; }
        public DbSet<tbUserOperateLog> tbUserOperateLog { get; set; }
    }
}
