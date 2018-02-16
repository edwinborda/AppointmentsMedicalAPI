using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dto
{
    public class PatientDto
    {
        public string Id { get; set; }

        public string last_name { get; set; }

        public string first_name { get; set; }
        
        public int identification { get; set; }

        public string genre { get; set; }

        public string civil_status { get; set; }

        public string blood_type { get; set; }
    }
}
