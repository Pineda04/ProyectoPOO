using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Destinations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/destinations")]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationsService _destinationService;

        public DestinationsController(IDestinationsService destinationService)
        {
            _destinationService = destinationService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<DestinationDto>>>> GetAll()
        {
            var response = await _destinationService.GetDestinationsListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<DestinationDto>>> Get(Guid id)
        {
            var response = await _destinationService.GetDestinationByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<DestinationDto>>> Create(DestinationCreateDto dto)
        {
            var response = await _destinationService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<DestinationDto>>> Edit(DestinationEditDto dto, Guid id)
        {
            var response = await _destinationService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<DestinationDto>>> Delete(Guid id)
        {
            var response = await _destinationService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
