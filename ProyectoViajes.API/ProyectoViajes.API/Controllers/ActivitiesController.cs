using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;
        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<ActivityDto>>> GetAll(){
            var response = await _activitiesService.GetActivitiesListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ActivityDto>>>Get(Guid id){
            var response = await _activitiesService.GetActivityByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear una actividad
        [HttpPost]
        public async Task<ActionResult<ResponseDto<ActivityDto>>> Create(ActivityCreateDto dto){
            var response = await _activitiesService.CreateActivityAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar una actividad
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<ActivityDto>>> Edit(ActivityEditDto dto, Guid id){
            var response = await _activitiesService.EditActivityAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }

        // Eliminar una actividad
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<ActivityDto>>> Delete(Guid id){
            var response = await _activitiesService.DeleteActivityAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}