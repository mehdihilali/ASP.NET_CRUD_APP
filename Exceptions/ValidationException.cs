namespace UserManagement.Exceptions
{
    public class ValidationException : ApiException
    {
        public ValidationException(Dictionary<string, List<string>> errors)
            : base(400, "Validation Failed")
        {
            ValidationErrors = errors;
        }

        public Dictionary<string, List<string>> ValidationErrors { get; set; }
    }
}
