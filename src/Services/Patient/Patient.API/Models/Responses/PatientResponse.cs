namespace Patient.API.Models.Responses
{
    public class PatientResponse
    {
        public string ecrf_no { get; set; }
        public int study_id { get; set; }
        public int inst_id { get; set; }
        public string shortname { get; set; }
        public string web_path { get; set; }
        public string site { get; set; }
    }
}