
using System.ComponentModel.DataAnnotations;


namespace MedicalAppointmentsAPI
{
    public class ReAssingmentAppointment
    {
        [Required]
        public string reassigmentDate { get; set; }


        public int doctorId { get; set; } = 0;
    }
}