namespace Administration.API.Model
{
    public class StudyModel
    {
        public class tbl_trialdetails
        {
            public int id { get; set; }
            public string shortname { get; set; }
            public string isrctn { get; set; }
            public string rec_ref { get; set; }
            public string mhra_ref { get; set; }
            public string sponsor { get; set; }
            public string funder { get; set; }
            public int trialactivitystatus_id { get; set; }
            public string notes { get; set; }
            public string trial_ref { get; set; }
            public int gcp_alert_period { get; set; }
            public int logo_id { get; set; }
            public string descr { get; set; }
        }

        public class tbl_activitystatus
        {
            public string descr { get; set; }
        }
    }
}