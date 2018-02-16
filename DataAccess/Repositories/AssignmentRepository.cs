using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AssignmentRepository : Repository<Assignments>
    {
        public AssignmentRepository(MedicalContext medicalContext)
            : base(medicalContext)
        {

        }

        public IEnumerable<Appointments> getAllAppointments(bool activeAppointment = true)
        {
            return context.Assigments.Include("Appointments")
                .Where(p => p.Appointments.Active == activeAppointment)
                .Select(p => p.Appointments).ToList();
        }

        public IEnumerable<Assignments> getAppointmentsByDoctor(int doctorId, bool activeAppointment = true)
        {
            return context.Assigments.Include("Appointments")
                .Where(p => p.Appointments.Active == activeAppointment).ToList();
        }

        public void cancelAppointment(int appointmentId)
        {
            var appointment = context.Assigments.Where(p => p.AppointmentsId == appointmentId)
                                                .Select(p => p.Appointments).FirstOrDefault();

            appointment.cancelMedicalAppointment();

            var lstAssingments = context.Assigments.Where(p => p.AppointmentsId == appointmentId).ToList();

            lstAssingments.ForEach(p => { p.Active = false; p.Appointments = appointment; });
            
        }
    }
}
