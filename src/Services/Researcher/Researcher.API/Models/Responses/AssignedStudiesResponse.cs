namespace Researcher.API.Models.Responses
{
    public class AssignedStudiesResponse
    {
        public int study_id { get; set; }
        public int inst_id { get; set; }
        public int person_id { get; set; }
        public string name { get; set; }
        public string shortname { get; set; }
        public string descr { get; set; }
        public int? logo_id { get; set; }
        public string image_name { get; set; }
        public string web_path { get; set; }
        public string system_path { get; set; }
    }
}