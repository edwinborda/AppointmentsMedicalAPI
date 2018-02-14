using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [Table("Assigments")]
    public class Assigments
    {
        private const int appointmentDuration = 10;

        internal Assigments()
        {

        }

        public Assigments(DateTime assignmentDate, int patientId, int doctorId)
        {
            if (assignmentDate < DateTime.Now)
                throw new ArgumentException("the date of the medical appointment can not be less than today.");

            createMedicalAppointment(patientId, doctorId);
            AssigmentInitialDate = assignmentDate;
            AppointmentDuration = appointmentDuration;
            AssigmentFinalDate = assignmentDate.AddMinutes(appointmentDuration);
            
        }
        public int Id { get; private set; }

        public DateTime AssigmentInitialDate { get; private set; }

        public DateTime AssigmentFinalDate { get; private set; }

        public int AppointmentsId { get; private set; }

        public int AppointmentDuration { get; private set; }
        public virtual Appointments Appointments { get; private set; }

        private void createMedicalAppointment(int patientId, int doctorId)
        {
            Appointments = new Appointments(patientId, doctorId);
            AppointmentsId = Appointments.Id;
        }
    }
}
