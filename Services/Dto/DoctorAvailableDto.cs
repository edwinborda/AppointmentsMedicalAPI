using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Dto
{
    public class DoctorAvailableDto
    {
        public const int DurationAvaibleMinutes = 15;
        public DoctorAvailableDto(DateTime dateInitial, DateTime dateEnd)
        {
            calcAllTimeFreeByDoctorId(dateInitial, dateEnd);
        }
        
        public ICollection<TimeFreeDto> timeFree { get; private set; }

        private void calcAllTimeFreeByDoctorId(DateTime dateInitial, DateTime dateEnd)
        {
            var minutes = dateEnd.Subtract(dateInitial).TotalMinutes;
            
            var count = Convert.ToInt32(dateEnd.Subtract(dateInitial).TotalMinutes) / DurationAvaibleMinutes;

            timeFree = new List<TimeFreeDto>();
            for (int i = 0; i < count; i++)
            {

                timeFree.Add(new TimeFreeDto()
                {
                    InitialDate = dateInitial.AddMinutes((DurationAvaibleMinutes* i) + 1),
                    FinalDate = dateInitial.AddMinutes(DurationAvaibleMinutes * (i + 1))
                });
            }

        }
    }
}
