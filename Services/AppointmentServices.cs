using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Entities;
using Services.Interfaces;


namespace Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly AssingmentRepository assingmentRepository;
        public AppointmentServices()
        {
            assingmentRepository = new AssingmentRepository(new DataAccess.Context.MedicalContext());
        }
        public bool cancelAppointment(int appointmentId)
        {
            assingmentRepository.cancelAppointment(appointmentId);

            return assingmentRepository.SaveChange();

        }

        public bool createAppointment(DateTime assingmentDate, int patientId, int doctorId)
        {
            var entity = new Assigments(assingmentDate, patientId, doctorId);

            assingmentRepository.add(entity);

            return assingmentRepository.SaveChange();
        }

        public IEnumerable<Appointments> getAllAppointments()
        {
            return assingmentRepository.getAllAppointments();
        }

        public Appointments getAppointmentById(int id)
        {
            return assingmentRepository.searchFor(p => p.AppointmentsId == id)
                    .Select(p => p.Appointments).FirstOrDefault() ?? throw new ArgumentNullException("Don't exist Medical appointment");
        }

        public bool modifyAppointment(DateTime reasingmentDate, int appointmentId, int doctorId = 0)
        {
            var appointment = getAppointmentById(appointmentId);
            appointment.modifyDoctor(doctorId);
            assingmentRepository.add(new Assigments(reasingmentDate, appointment));

            return assingmentRepository.SaveChange();
        }
    }
}
