using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Reservations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService _reservationsService;
        public ReservationsController(IReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ReservationDto>>>> GetAll(){
            var response = await _reservationsService.GetReservationsListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<ReservationDto>>>> Get(Guid id){
            var response = await _reservationsService.GetReservationByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear una reservación
        [HttpPost]
        public async Task<ActionResult<ResponseDto<List<ReservationDto>>>> Create(ReservationCreateDto dto){
            var response = await _reservationsService.CreateReservationAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar una reservación
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<ReservationDto>>>> Edit(ReservationEditDto dto, Guid id){
            var response = await _reservationsService.EditReservationAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar una reservación
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<List<ReservationDto>>>> Delete(Guid id){
            var response = await _reservationsService.DeleteReservationAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}