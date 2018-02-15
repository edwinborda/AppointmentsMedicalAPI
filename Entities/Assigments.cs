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
        public const int appointmentDuration = 10;

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

        public Assigments(DateTime reasingmentDate, Appointments appointment)
        {
            AssigmentInitialDate = reasingmentDate;
            AppointmentDuration = appointmentDuration;
            AssigmentFinalDate = reasingmentDate.AddMinutes(appointmentDuration);
            Appointments = appointment;
            AppointmentsId = Appointments.Id;
        }

        public int Id { get; private set; }

        public DateTime AssigmentInitialDate { get; private set; }

        public DateTime AssigmentFinalDate { get; private set; }

        public int AppointmentsId { get; private set; }

        public int AppointmentDuration { get; private set; }

        public bool Active { get; set; } = true;
        
        public virtual Appointments Appointments { get;     set; }

        private void createMedicalAppointment(int patientId, int doctorId)
        {
            Appointments = new Appointments(patientId, doctorId);
            AppointmentsId = Appointments.Id;
        }

    }
}
