namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTableAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assigments", "AppointmentsId", "dbo.Appointments");
            DropIndex("dbo.Assigments", new[] { "AppointmentsId" });
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentInitialDate = c.DateTime(nullable: false),
                        AssignmentFinalDate = c.DateTime(nullable: false),
                        AppointmentsId = c.Int(nullable: false),
                        AppointmentDuration = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentsId, cascadeDelete: true)
                .Index(t => t.AppointmentsId);
            
            DropTable("dbo.Assigments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Assigments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssigmentInitialDate = c.DateTime(nullable: false),
                        AssigmentFinalDate = c.DateTime(nullable: false),
                        AppointmentsId = c.Int(nullable: false),
                        AppointmentDuration = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Assignments", "AppointmentsId", "dbo.Appointments");
            DropIndex("dbo.Assignments", new[] { "AppointmentsId" });
            DropTable("dbo.Assignments");
            CreateIndex("dbo.Assigments", "AppointmentsId");
            AddForeignKey("dbo.Assigments", "AppointmentsId", "dbo.Appointments", "Id", cascadeDelete: true);
        }
    }
}
