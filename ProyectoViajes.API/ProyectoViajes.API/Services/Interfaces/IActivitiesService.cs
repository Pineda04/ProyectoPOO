using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Common;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IActivitiesService
    {
        Task<ResponseDto<PaginationDto<List<ActivityDto>>>> GetActivitiesListAsync(string searchTerm = "", int page = 1);

        Task<ResponseDto<ActivityDto>> GetActivityByIdAsync(Guid id);

        Task<ResponseDto<ActivityDto>> CreateActivityAsync(ActivityCreateDto dto);

        Task<ResponseDto<ActivityDto>> EditActivityAsync(ActivityEditDto dto, Guid id);
        
        Task<ResponseDto<ActivityDto>> DeleteActivityAsync(Guid id);
    }
}