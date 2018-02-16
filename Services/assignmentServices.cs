using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Services.Interfaces;
using Services.Dto;
using DataAccess.Repositories;
using RestSharp;
using Newtonsoft.Json;

namespace Services
{
    public class assignmentServices : IAssignmentServices
    {
        private readonly AssignmentRepository assignmentRepository;
        public assignmentServices()
        {
            assignmentRepository = new AssignmentRepository(new DataAccess.Context.MedicalContext());
        }
        private IEnumerable<Assignments> getAssignmentByDoctorId(int doctorId)
        {
            return assignmentRepository.searchFor(p => p.Appointments.DoctorId == doctorId).ToList();
        }

        public IEnumerable<DoctorAssignmentsDto> getAssignmentByDoctor(int doctorId)
        {
            List<DoctorAssignmentsDto> lstAssignDetail = new List<DoctorAssignmentsDto>();
            var lstAssign = assignmentRepository.getAppointmentsByDoctor(doctorId).ToList();

            foreach (var item in lstAssign)
            {
                lstAssignDetail.Add(new DoctorAssignmentsDto()
                {
                    Id = item.Id,
                    DoctorId = item.Appointments.DoctorId,
                    InitialDateTime = item.AssignmentInitialDate,
                    FinalDateTime = item.AssignmentFinalDate,
                    Patient = GetPatient(item.Appointments.PatientId)
                });
            }

            return lstAssignDetail;
        }

        public PatientDto GetPatient(int id)
        {
            var client = new RestClient("http://pruebas.apimedic.personalsoft.net:8082/api/v1/");
            var request = new RestRequest($"patients/{id}", Method.GET);
            var result = client.Execute(request).Content;
            var entity = JsonConvert.DeserializeObject<PatientDto>(result);

            return entity;
        }

        public ICollection<TimeFreeDto> getTimeFreeByDoctorID(int doctorId, DateTime initialDate, DateTime finalDate)
        {

            var listAllTimeFree = new DoctorAvailableDto(initialDate, finalDate).timeFree;

            var listAssignmentByDoctor = getAssignmentByDoctorId(doctorId);

            listAssignmentByDoctor.ToList().ForEach(p =>
            {
                var result = (from a in listAllTimeFree
                              where p.AssignmentInitialDate >= a.InitialDate &&
                                     p.AssignmentFinalDate <= a.FinalDate
                              select a).ToList();

                foreach (var item in result)
                {
                    listAllTimeFree.Remove(item);
                }


            });

            return listAllTimeFree;

        }
    }
}
