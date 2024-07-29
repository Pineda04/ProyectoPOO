using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/pointsinterests")]
    public class PointsInterestController : ControllerBase
    {
        private readonly IPointsInterestService _pointInterestService;

        public PointsInterestController(IPointsInterestService pointInterestService)
        {
            _pointInterestService = pointInterestService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<PointInterestDto>>>> GetAll()
        {
            var response = await _pointInterestService.GetPointsInterestListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<PointInterestDto>>> Get(Guid id)
        {
            var response = await _pointInterestService.GetPointInterestByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<PointInterestDto>>> Create(PointInterestCreateDto dto)
        {
            var response = await _pointInterestService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<PointInterestDto>>> Edit(PointInterestEditDto dto, Guid id)
        {
            var response = await _pointInterestService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<PointInterestDto>>> Delete(Guid id)
        {
            var response = await _pointInterestService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
