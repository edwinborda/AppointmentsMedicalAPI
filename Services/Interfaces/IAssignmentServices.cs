using Entities;
using Services.Dto;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAssignmentServices
    {
        IEnumerable<DoctorAssignmentsDto> getAssignmentByDoctor(int doctorId);

        ICollection<TimeFreeDto> getTimeFreeByDoctorID(int doctorId, DateTime initialDate, DateTime finalDate);
    }
}
