namespace Administration.API.Model
{
    public class IndividualModel
    {
        public class tbl_persondetails
        {
            public int id { get; set; }
            public int title_id { get; set; }
            public string given_name { get; set; }
            public string middle_name { get; set; }
            public string family_name { get; set; }
            public string preferred_name { get; set; }
            public string previous_name { get; set; }
            public string tel_no { get; set; }
            public int main_job_title_id { get; set; }
            public int secondary_job_title_id { get; set; }
            public int cv_received_id { get; set; }
            public string email { get; set; }
            public string secretary_name { get; set; }
            public string secretary_tel { get; set; }
            public string secretary_email { get; set; }
            public string notes { get; set; }
            public string username { get; set; }
            public string pwd { get; set; }
            public int priv_id { get; set; }
            public string gcp_start_date { get; set; }
            public bool active { get; set; }
        }

        public class tbl_title
        {
            public string descr { get; set; }
        }

        public class tbl_receivedstatus
        {
            public string descr { get; set; }
        }

        public class tbl_privileges
        {
            public string descr { get; set; }
        }

        public class tbl_jobtitle
        {
            public string descr { get; set; }
        }
    }
}