using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Reservations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{

    [ApiController]
     
      [Route("api/reservations")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this._reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ReservationDto>>>> GetAll()
        {
            var response = await _reservationService.GetReservationsListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ReservationDto>>> Get(Guid id)
        {
            var response = await _reservationService.GetReservationByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ReservationDto>>> Create(CreateReservationDto dto)
        {
            var response = await _reservationService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<ReservationDto>>> Edit(EditReservationDto dto, Guid id)
        {
            var response = await _reservationService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<ReservationDto>>> Delete(Guid id)
        {
            var response = await _reservationService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
