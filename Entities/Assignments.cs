using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [Table("Assignments")]
    public class Assignments
    {
        public const int appointmentDuration = 10;

        internal Assignments()
        {

        }

        public Assignments(DateTime assignmentDate, int patientId, int doctorId)
        {
            if (assignmentDate < DateTime.Now)
                throw new ArgumentException("the date of the medical appointment can not be less than today.");

            createMedicalAppointment(patientId, doctorId);
            AssignmentInitialDate = assignmentDate;
            AppointmentDuration = appointmentDuration;
            AssignmentFinalDate = assignmentDate.AddMinutes(appointmentDuration);

        }

        public Assignments(DateTime reasingmentDate, Appointments appointment)
        {
            AssignmentInitialDate = reasingmentDate;
            AppointmentDuration = appointmentDuration;
            AssignmentFinalDate = reasingmentDate.AddMinutes(appointmentDuration);
            Appointments = appointment;
            AppointmentsId = Appointments.Id;
        }

        public int Id { get; private set; }

        public DateTime AssignmentInitialDate { get; private set; }

        public DateTime AssignmentFinalDate { get; private set; }

        public int AppointmentsId { get; private set; }

        public int AppointmentDuration { get; private set; }

        public bool Active { get; set; } = true;

        public virtual Appointments Appointments { get; set; }

        private void createMedicalAppointment(int patientId, int doctorId)
        {
            Appointments = new Appointments(patientId, doctorId);
            AppointmentsId = Appointments.Id;
        }
        
    }
}
