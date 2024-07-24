using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/agencies")]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgenciesService _agenciesService;

        public List<AgencyEntity> _agencies { get; set; }

        public AgenciesController(IAgenciesService agenciesService)
        {
            this._agenciesService = agenciesService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<AgencyDto>>> GetAll()
        {
            var response = await _agenciesService.GetAgenciesListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id 
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<AgencyDto>>> Get(Guid id)
        {
            var response = await _agenciesService.GetAgencyByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear 
        [HttpPost]
        public async Task<ActionResult<ResponseDto<AgencyDto>>> Create(AgencyCreateDto dto)
        {
            var response = await _agenciesService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<AgencyDto>>> Edit(AgencyEditDto dto, Guid id)
        {
            var response = await _agenciesService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<AgencyDto>>> Delete(Guid id)
        {
            var response = await _agenciesService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
