using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AppointmentsRepository: Repository<Appointments>
    {
        public AppointmentsRepository(MedicalContext medicalContext )
            : base(medicalContext)
        {

        }
        
        

    }
}
