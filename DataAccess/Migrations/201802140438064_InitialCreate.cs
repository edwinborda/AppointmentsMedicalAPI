namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.AppointmentsId, cascadeDelete: true)
                .Index(t => t.AppointmentsId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assigments", "AppointmentsId", "dbo.Appointments");
            DropIndex("dbo.Assigments", new[] { "AppointmentsId" });
            DropTable("dbo.Appointments");
            DropTable("dbo.Assigments");
        }
    }
}
