using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.Common;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IAgenciesService
    {
        Task<ResponseDto<List<AgencyDto>>> GetAgenciesListAsync();

        Task<ResponseDto<AgencyDto>> GetAgencyByIdAsync(Guid id);

        Task<ResponseDto<AgencyDto>> CreateAgencyAsync(AgencyCreateDto dto);

        Task<ResponseDto<AgencyDto>> EditAgencyAsync(AgencyEditDto dto ,Guid id);

        Task<ResponseDto<AgencyDto>> DeleteAgencyAsync(Guid id);
    }
}