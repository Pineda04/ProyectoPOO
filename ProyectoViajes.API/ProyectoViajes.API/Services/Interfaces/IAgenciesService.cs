using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.common;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IAgenciesService
    {
        Task<ResponseDto<List<AgencyDto>>> GetAgenciesListAsync();

        Task<ResponseDto<AgencyDto>> GetAgencyByIdAsync(Guid id); 

        Task<ResponseDto<AgencyDto>> CreateAsync(AgencyCreateDto dto);

        Task<ResponseDto<AgencyDto>> EditAsync (AgencyEditDto dto, Guid id);

        Task<ResponseDto<AgencyDto>> DeleteAsync(Guid id);
    }
}
