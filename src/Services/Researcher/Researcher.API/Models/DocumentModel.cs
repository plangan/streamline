namespace Researcher.API.Models
{
    public class DocumentModel
    {
        public class tbl_documents
        {
            public int id { get; set; }
            public string filename { get; set; }
            public string descr { get; set; }
            public int size { get; set; }
            public int study_id { get; set; }
            public int inst_id { get; set; }
            public int uploaded_by { get; set; }
            public string location { get; set; }
            public string upload_date { get; set; }
            public int ctu_status_id { get; set; }
            public string ctu_appr_date { get; set; }
            public int ctu_appr_by { get; set; }
            public int site_status_id { get; set; }
            public string site_appr_date { get; set; }
            public string site_appr_by { get; set; }
            public int sponsor_status_id { get; set; }
            public string sponsor_appr_date { get; set; }
            public string sponsor_appr_by { get; set; }
            public bool active { get; set; }
            public int dist_type_id { get; set; }
            public int parent_id { get; set; }
            public string uri { get; set; }
        }

        public class tbl_trialdetails
        {
            public string shortname { get; set; }
        }

        public class tbl_institutiondetails
        {
            public string institution { get; set; }
        }

        public class tbl_persondetails
        {
            public string given_name { get; set; }
            public string family_name { get; set; }
        }

        public class tbl_ctu_status
        {
            public string descr { get; set; }
        }

        public class ctuperson
        {
            public string given_name { get; set; }
            public string family_name { get; set; }
        }

        public class tbl_local_status
        {
            public string descr { get; set; }
        }

        public class tbl_sponsor_status
        {
            public string descr { get; set; }
        }

        public class sponsorperson
        {
            public string given_name { get; set; }
            public string family_name { get; set; }
        }

        public class tbl_dist_type
        {
            public string descr { get; set; }
        }
    }
}