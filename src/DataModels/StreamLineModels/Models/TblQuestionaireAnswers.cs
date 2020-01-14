using System;
using System.Collections.Generic;

namespace StreamLineModels.Models
{
    public partial class TblQuestionaireAnswers
    {
        public int QuestionaireId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
