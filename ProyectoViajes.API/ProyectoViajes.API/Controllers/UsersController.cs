using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Users;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<UserDto>>>> GetAll(){
            var response = await _usersService.GetUsersListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<UserDto>>>> Get(Guid id){
            var response = await _usersService.GetUserByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear un usuario
        [HttpPost]
        public async Task<ActionResult<ResponseDto<List<UserDto>>>> Create(UserCreateDto dto){
            var response = await _usersService.CreateUserAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar un usuario
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<UserDto>>>> Edit(UserEditDto dto, Guid id){
            var response = await _usersService.EditUserAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar un usuario
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<List<UserDto>>>> Delete(Guid id){
            var response = await _usersService.DeleteUserAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}