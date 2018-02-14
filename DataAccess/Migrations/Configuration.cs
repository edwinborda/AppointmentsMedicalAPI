namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.MedicalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Context.MedicalContext context)
        {
            //create one medical appointment with a assingment
            context.Assigments.AddOrUpdate(new Assigments(DateTime.Now.AddDays(1),17, 3));
            
        }
    }
}
