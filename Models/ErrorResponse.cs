using System.Text.Json.Serialization;

namespace UserManagement.Models
{
    public class ErrorResponse
    {
        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("details")]
        public string? Details { get; set; }

        [JsonPropertyName("validationErrors")]
        public Dictionary<string, List<string>>? ValidationErrors { get; set; }

        [JsonPropertyName("stackTrace")]
        public string? StackTrace { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Timestamp = DateTime.UtcNow;
        }

        public ErrorResponse(int statusCode, string message, string? details) : this(statusCode, message)
        {
            Details = details;

        }
    }
}
