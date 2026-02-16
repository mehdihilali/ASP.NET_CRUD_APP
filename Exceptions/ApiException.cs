namespace UserManagement.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string? Details { get; set; }

        public ApiException(int statusCode, string message): base(message)
        {
            StatusCode = statusCode; 
        }

        public ApiException(int statusCode, string message, string? details) : base(message)
        {
            StatusCode = statusCode;
            Details = details;
        }

        public ApiException(int statusCode, string message, Exception inneException) : base(message, inneException)
        {
            StatusCode = statusCode;
        }
    }
}
