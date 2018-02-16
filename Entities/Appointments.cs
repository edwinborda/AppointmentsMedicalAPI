using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Appointments")]
    public class Appointments
    {
        internal Appointments()
        {

        }
        public Appointments(int patientId, int doctorId)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            CreateAt = DateTime.Now;
        }
        public int Id { get; private set; }

        public int PatientId { get; private set; }
        
        public int DoctorId { get; set; }
        
        public DateTime CreateAt { get; private set; }

        public bool Active { get; private set; } = true;

        public void cancelMedicalAppointment()
        {
            Active = false;
        }

        public void modifyDoctor(int doctorId)
        {
            if (doctorId == 0)
                return;

            DoctorId = doctorId;
        }
       
    }
}
