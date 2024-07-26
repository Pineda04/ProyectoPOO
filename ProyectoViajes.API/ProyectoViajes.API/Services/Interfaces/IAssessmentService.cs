using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.common;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IAssessmentService
    {
        Task<ResponseDto<List<AssessmentDto>>> GetAssessmentsAsync();
        Task<ResponseDto<AssessmentDto>> GetAssessmentByIdAsync(Guid id);
        Task<ResponseDto<AssessmentDto>> CreateAsync(CreateAssessmentDto dto);
        Task<ResponseDto<AssessmentDto>> EditAsync(EditAssessmentDto dto, Guid id);
        Task<ResponseDto<AssessmentDto>> DeleteAsync(Guid id);
    }
}
