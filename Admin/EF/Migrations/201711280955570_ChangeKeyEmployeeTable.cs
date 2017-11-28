namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeyEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Position", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Position", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
