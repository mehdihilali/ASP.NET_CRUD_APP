using UserManagement.DTO;

namespace UserManagement.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(CreateUserDto userDto);
        Task UpdateAsync(Guid id, UpdateUserDto dto);
        Task DeleteAsync(Guid id);
    }
}
