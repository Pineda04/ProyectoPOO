using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.Common;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IAssessmentService
    {
        Task<ResponseDto<PaginationDto<List<AssessmentDto>>>> GetAssessmentsListAsync(int page = 1);

        Task<ResponseDto<AssessmentDto>> GetAssessmentByIdAsync(Guid id);

        Task<ResponseDto<AssessmentDto>> CreateAssessmentAsync(AssessmentCreateDto dto);

        Task<ResponseDto<AssessmentDto>> EditAssessmentAsync(AssessmentEditDto dto, Guid id);

        Task<ResponseDto<AssessmentDto>> DeleteAssessmentAsync(Guid id);
    }
}