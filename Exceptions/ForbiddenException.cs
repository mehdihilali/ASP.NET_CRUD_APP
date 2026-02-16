namespace UserManagement.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message)
            : base(403, message) { }

        public ForbiddenException(string message, string? details)
            : base(403, message, details) { }
    }
}
