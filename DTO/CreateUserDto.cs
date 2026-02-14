namespace UserManagement.DTO
{
    public record CreateUserDto(
        string FirstName,
        string LastName,
        string Email,
        int Age
        );
}
