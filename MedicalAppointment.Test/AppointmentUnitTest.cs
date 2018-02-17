using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace MedicalAppointment.Test
{
    [TestClass]
    public class AppointmentUnitTest
    {
        [TestMethod]
        public void IsAppointment()
        {
            var patientId = 11;
            var doctorId = 3;
            var entity = new Assignments(DateTime.Now.AddDays(1), patientId, doctorId);

            Assert.AreNotEqual(null, entity);
        }

        [TestMethod]
        public void IscancelAppointment()
        {
            var patientId = 11;
            var doctorId = 3;
            var entity = new Assignments(DateTime.Now.AddDays(1), patientId, doctorId);

            entity.Appointments.cancelMedicalAppointment();

            Assert.AreEqual(false, entity.Appointments.Active);
        }

        [TestMethod]
        public void CanChangeDoctorForAppointment()
        {
            var patientId = 11;
            var doctorId = 3;
            var entity = new Assignments(DateTime.Now.AddDays(1), patientId, doctorId);

            entity.Appointments.modifyDoctor(4);

            Assert.AreEqual(4, entity.Appointments.DoctorId);
        }

        [TestMethod]
        public void CorrectDurationForAppointment()
        {
            var patientId = 11;
            var doctorId = 3;
            var entity = new Assignments(DateTime.Now.AddDays(1), patientId, doctorId);

            Assert.AreEqual(true, (entity.AssignmentFinalDate > entity.AssignmentInitialDate
                                    && entity.AssignmentFinalDate.Subtract(entity.AssignmentInitialDate).TotalMinutes == 10));
        }

        [TestMethod]
        public void CanBeModifyAppointment()
        {
            var patientId = 11;
            var doctorId = 3;
            var entity = new Assignments(DateTime.Now.AddDays(1), patientId, doctorId);

            var newEntity = new Assignments(DateTime.Now.AddDays(2), entity.Appointments);

            Assert.AreEqual(DateTime.Now.AddDays(2), newEntity.AssignmentInitialDate);
        }
        
    }
}
