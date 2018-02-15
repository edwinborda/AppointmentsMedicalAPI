using Entities;
using Entities.ValueObjects;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAssingmentServices
    {
        IEnumerable<Assigments> getAssingmentByDoctorId(int doctorId);

        IEnumerable<TimeFree> getTimeFreeByDoctorID(int doctorId);
    }
}
