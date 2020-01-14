using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblSysupdate
    {
        public string Sys { get; set; }
        public int Seq { get; set; }
        public DateTime? DateUpd { get; set; }
        public string Vers { get; set; }
        public string Notes { get; set; }
    }
}
