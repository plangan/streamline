namespace Researcher.API.Models.Responses.GrandChild
{
    public class GrandChildResponse
    {
        public string parentID { get; set; }
        public string childID { get; set; }
        public string grandChildID { get; set; }
        public string grandChildDescr { get; set; }
        public string grandChildColour { get; set; }
    }
}