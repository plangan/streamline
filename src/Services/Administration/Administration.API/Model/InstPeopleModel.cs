namespace Administration.API.Model
{
    public class InstPeopleModel
    {
        public class tbl_instpeople
        {
            public int person_id { get; set; }
            public int inst_id { get; set; }
            public bool prime { get; set; }
            public int inst_role_id { get; set; }
            public string note { get; set; }
        }

        public class tbl_persondetails
        {
            public string given_name { get; set; }
            public string family_name { get; set; }
        }

        public class tbl_institutiondetails
        {
            public string institution { get; set; }
        }

        public class tbl_jobtitle
        {
            public string descr { get; set; }
        }
    }
}