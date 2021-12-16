using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerveysKyselyOY.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }

        public List<Inquiry> Inquiries { get; set; }

    }
}
