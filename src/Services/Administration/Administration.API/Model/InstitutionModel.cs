namespace Administration.API.Model
{
    public class InstitutionModel
    {
        public class tbl_institutiondetails
        {
            public int id { get; set; }
            public string institution { get; set; }
            public string url { get; set; }
            public string city { get; set; }
            public int ctry_id { get; set; }
            public string postcode { get; set; }
            public string adr_notes { get; set; }
            public string tel_no { get; set; }
            public int activity_status_id { get; set; }
            public string notes { get; set; }
            public bool active { get; set; }
            public int gcp_period { get; set; }
        }

        public class tbl_ctry
        {
            public string descr { get; set; }
        }

        public class tbl_activitystatus
        {
            public string descr { get; set; }
        }
    }
}