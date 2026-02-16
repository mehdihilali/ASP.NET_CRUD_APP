namespace UserManagement.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string resourceName, object? id) : base(404, $"The {resourceName} with ID {id} was not found.")
        {
            ResourceName = resourceName;
            ResourceId = id?.ToString();
        }

        public string ResourceName { get; }
        public string? ResourceId { get; }
    }
}
