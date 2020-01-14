namespace Administration.API.Model.Responses.Site
{
    public class SiteResponse
    {
        public int id { get; set; }
        public string institution { get; set; }
        public string url { get; set; }
        public string city { get; set; }
        public int ctry_id { get; set; }

        //public string ctry { get; set; }
        public string postcode { get; set; }

        public string tel_no { get; set; }
        public string email { get; set; }
        public int activity_status_id { get; set; }

        //public string activity_status { get; set; }
        public string notes { get; set; }

        public bool active { get; set; }
        public string inst_ref { get; set; }
        public string spare01 { get; set; }
        public string spare02 { get; set; }
        public string spare03 { get; set; }
        public string spare01Lbl { get; set; }
        public string spare02Lbl { get; set; }
        public string spare03Lbl { get; set; }
        public int gcp_period { get; set; }
    }
}