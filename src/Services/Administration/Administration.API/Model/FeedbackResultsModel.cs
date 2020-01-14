namespace Administration.API.Model
{
    public class FeedbackResultsModel
    {
        public class tbl_feedback
        {
            public string ecrf_no { get; set; }
            public int seq { get; set; }
            public string datim { get; set; }
            public bool negative_comments { get; set; }
            public bool send_to_nurse { get; set; }
            public string feedback { get; set; }
        }
    }
}