using Entities;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAppointmentServices
    {
        IEnumerable<Appointments> getAllAppointments();

        Appointments getAppointmentById(int id);

        bool createAppointment(DateTime assingmentDate, int patientId, int doctorId);

        bool modifyAppointment(DateTime reasingmentDate, int appointmentId, int doctorId = 0);

        bool cancelAppointment(int id);
    }
}
