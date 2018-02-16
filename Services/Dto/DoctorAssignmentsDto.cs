using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class DoctorAssignmentsDto
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public DateTime InitialDateTime { get; set; }

        public DateTime FinalDateTime { get; set; }

        public PatientDto Patient { get; set; }
    }
}
