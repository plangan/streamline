namespace Patient.API.Models.Responses
{
    public class FeedbackResponse
    {
        public string ecrf_no { get; set; }

        public int seq { get; set; }

        public bool negative_comments { get; set; }

        public bool send_to_nurse { get; set; }

        public string feedback { get; set; }

        public int study_id { get; set; }

        public int inst_id { get; set; }
    }
}