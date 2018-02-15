using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ValueObjects
{
    public class TimeFree
    {
        public TimeFree(int doctorId, DateTime dateInitial, DateTime dateEnd)
        {
            DoctorId = doctorId;

            calcAllTimeFreeByDoctorId(dateInitial, dateEnd);
        }
        public int DoctorId { get; private set; }

        public ICollection<DateTime> timeFree { get; private set; }

        private void calcAllTimeFreeByDoctorId(DateTime dateInitial, DateTime dateEnd)
        {
            timeFree = Enumerable.Range(0, Assigments.appointmentDuration + dateEnd.Subtract(dateInitial).Minutes)
                    .Select(offset => dateInitial.AddDays(offset))
                    .ToList();
        }
    }
}
