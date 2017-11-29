namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDataAnotationTableEmployee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Position", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Position", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
        }
    }
}
