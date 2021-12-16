using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerveysKyselyOY.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public bool IsPointWorth { get; set; }

    }
}
