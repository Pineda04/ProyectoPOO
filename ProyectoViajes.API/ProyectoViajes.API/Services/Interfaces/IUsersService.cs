using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Users;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseDto<List<UserDto>>> GetUsersListAsync();

        Task<ResponseDto<UserDto>> GetUserByIdAsync(Guid id);

        Task<ResponseDto<UserDto>> CreateUserAsync(UserCreateDto dto);

        Task<ResponseDto<UserDto>> EditUserAsync(UserEditDto dto, Guid id);
        
        Task<ResponseDto<UserDto>> DeleteUserAsync(Guid id);
    }
}