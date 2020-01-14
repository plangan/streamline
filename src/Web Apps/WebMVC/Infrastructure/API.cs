namespace WebMVC.Infrastructure
{
    public static class API
    {
        public static class Authentication
        {
            public static string Authenticate(string baseUri) => $"{baseUri}/user/authenticate";
        }
    }
}