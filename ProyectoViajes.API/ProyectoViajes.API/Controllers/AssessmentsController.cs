using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/assessments")]
    public class AssessmentsController : ControllerBase
    {
        private readonly IAssessmentService _assessmentService;
        public AssessmentsController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<AssessmentDto>>>> GetAll(int page = 1)
        {
            var response = await _assessmentService.GetAssessmentsListAsync(page);
            return StatusCode(response.StatusCode, response);
        }

        // Traer por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<List<AssessmentDto>>>> Get(Guid id)
        {
            var response = await _assessmentService.GetAssessmentByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear un destino
        [HttpPost]
        public async Task<ActionResult<ResponseDto<List<AssessmentDto>>>> Create(AssessmentCreateDto dto)
        {
            var response = await _assessmentService.CreateAssessmentAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar un destino
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<List<AssessmentDto>>>> Edit(AssessmentEditDto dto, Guid id)
        {
            var response = await _assessmentService.EditAssessmentAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar un destino
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<List<AssessmentDto>>>> Delete(Guid id)
        {
            var response = await _assessmentService.DeleteAssessmentAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}