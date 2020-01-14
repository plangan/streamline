using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblPatient
    {
        public string EcrfNo { get; set; }
        public int? NumTimesLogged { get; set; }
        public string Pwd { get; set; }
        public string Nurse { get; set; }
        public string NurseEmail { get; set; }
        public string Notes { get; set; }
    }
}
