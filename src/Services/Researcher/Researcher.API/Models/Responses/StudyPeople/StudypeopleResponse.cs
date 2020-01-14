namespace Researcher.API.Models.Responses.StudyPeople
{
    public class StudypeopleResponse
    {
        public int study_id { get; set; }
        public string study { get; set; }
        public int inst_id { get; set; }
        public string site { get; set; }
        public int person_id { get; set; }
        public string fullname { get; set; }
        public bool main { get; set; }
        public string invite_date { get; set; }
        public string response_date { get; set; }
        public int study_role_id { get; set; }
        public bool active { get; set; }
        public string note { get; set; }
    }
}