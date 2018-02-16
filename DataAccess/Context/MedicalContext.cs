using Entities;

namespace DataAccess.Context
{
    public class MedicalContext : System.Data.Entity.DbContext
    {
        public MedicalContext() : base("name=MedicalAppointMentConnection")
        {

        }
        
        public virtual System.Data.Entity.DbSet<Assignments> Assigments { get; set; }
        
    }
}
