namespace API.Errors
{
    public class ApiException(int statusCode,string messsage,string? details)
    {
        public int StatusCode { get; set; }
        public string Messsage { get; set; }
        public string? Details { get; set; }

    }
}
