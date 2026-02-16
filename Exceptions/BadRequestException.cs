namespace UserManagement.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) 
            : base(400, message) { }
        public BadRequestException(string message, string? details) 
            : base(400, message, details) { }
    }
}
