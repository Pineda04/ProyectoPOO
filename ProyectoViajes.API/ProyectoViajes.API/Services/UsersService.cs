using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Users;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class UsersService : IUsersService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public UsersService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<UserDto>>> GetUsersListAsync()
        {
            var usersEntity = await _context.Users.ToListAsync();

            var usersDto = _mapper.Map<List<UserDto>>(usersEntity);

            return new ResponseDto<List<UserDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = usersDto
            };
        }

        public async Task<ResponseDto<UserDto>> GetUserByIdAsync(Guid id)
        {
            var usersEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(usersEntity == null){
                return new ResponseDto<UserDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var usersDto = _mapper.Map<UserDto>(usersEntity);

            return new ResponseDto<UserDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = usersDto
            };
        }

        public async Task<ResponseDto<UserDto>> CreateUserAsync(UserCreateDto dto)
        {
            var usersEntity = _mapper.Map<UserEntity>(dto);

            _context.Users.Add(usersEntity);

            await _context.SaveChangesAsync();

            var usersDto = _mapper.Map<UserDto>(usersEntity);

            return new ResponseDto<UserDto>
            {
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = usersDto
            };
        }

        public async Task<ResponseDto<UserDto>> EditUserAsync(UserEditDto dto, Guid id)
        {
            var usersEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(usersEntity == null){
                return new ResponseDto<UserDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, usersEntity);

            _context.Users.Update(usersEntity);

            await _context.SaveChangesAsync();

            var usersDto = _mapper.Map<UserDto>(usersEntity);

            return new ResponseDto<UserDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = usersDto
            };
        }

        public async Task<ResponseDto<UserDto>> DeleteUserAsync(Guid id)
        {
            var usersEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if(usersEntity == null){
                return new ResponseDto<UserDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Users.Remove(usersEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<UserDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}