using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblQuestionaire
    {
        public int Id { get; set; }
        public string EcrfNo { get; set; }
        public int TemplateId { get; set; }
        public int StudyId { get; set; }
        public DateTime? Datim { get; set; }
        public sbyte? Commplete { get; set; }
    }
}
