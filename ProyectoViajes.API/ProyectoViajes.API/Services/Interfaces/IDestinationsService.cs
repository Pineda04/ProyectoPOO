using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Destinations;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IDestinationsService
    {
        Task<ResponseDto<List<DestinationDto>>> GetDestinationsListAsync();

        Task<ResponseDto<DestinationDto>> GetDestinationByIdAsync(Guid id);

        Task<ResponseDto<DestinationDto>> CreateDestinationAsync(DestinationCreateDto dto);

        Task<ResponseDto<DestinationDto>> EditDestinationAsync(DestinationEditDto dto, Guid id);

        Task<ResponseDto<DestinationDto>> DeleteDestinationAsync(Guid id);
    }
}