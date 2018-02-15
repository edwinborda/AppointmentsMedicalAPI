namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveColumnInAssigment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assigments", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assigments", "Active");
        }
    }
}
