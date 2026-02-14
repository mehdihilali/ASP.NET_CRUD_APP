namespace UserManagement.DTO
{
    public record UserDto(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        int Age,
        DateTime CreatedAt
        );
}
