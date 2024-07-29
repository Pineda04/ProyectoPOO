using Microsoft.AspNetCore.Mvc;
using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Controllers
{
    [ApiController]
    [Route("api/assessments")]
    public class AssessmentController : ControllerBase
    {
        private readonly IAssessmentService _assessmentService;

        public AssessmentController(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<AssessmentDto>>>> GetAll()
        {
            var response = await _assessmentService.GetAssessmentsAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<AssessmentDto>>> Get(Guid id)
        {
            var response = await _assessmentService.GetAssessmentByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<AssessmentDto>>> Create(CreateAssessmentDto dto)
        {
            var response = await _assessmentService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<AssessmentDto>>> Edit(EditAssessmentDto dto, Guid id)
        {
            var response = await _assessmentService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<AssessmentDto>>> Delete(Guid id)
        {
            var response = await _assessmentService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
