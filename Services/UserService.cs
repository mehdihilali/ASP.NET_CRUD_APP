using AutoMapper;
using UserManagement.DTO;
using UserManagement.Models;
using UserManagement.Repository;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("Email is required");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Age = dto.Age,
                CreatedAt = DateTime.UtcNow
            };

            var savedUser = await _repository.AddAsync(user);
            return _mapper.Map<UserDto>(savedUser);
        }

        public async Task UpdateAsync(Guid id, UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Age = dto.Age;

            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} Not fount");

            await _repository.DeleteAsync(user);
        }
    }
}
