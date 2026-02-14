namespace UserManagement.DTO
{
    public record UpdateUserDto(
        string FirstName,
        string LastName,
        string Email,
        int Age
        );
}
