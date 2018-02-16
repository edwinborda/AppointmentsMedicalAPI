using System;
using System.Linq;
using Services.Dto;

namespace MedicalAppointmentsAPI.Validations
{
    public static class ValidatorTools
    {
        public static bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }

        public static bool BeInValidDateRange(string value)
        {
            DateTime date;
            DateTime.TryParse(value, out date);

            var timefree = new DoctorAvailableDto(Convert.ToDateTime("1900-01-01"), 
                                                  Convert.ToDateTime("1900-01-02")).timeFree;

            var result = timefree.Select(p => p.InitialDate.ToShortTimeString());


            return result.Contains(date.ToShortTimeString());

        }
    }
}