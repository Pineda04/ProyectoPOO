using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Dtos.Destinations;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IDestinationsService
    {
        Task<ResponseDto<List<DestinationDto>>> GetDestinationsListAsync();

        Task<ResponseDto<DestinationDto>> GetDestinationByIdAsync(Guid id);

        Task<ResponseDto<DestinationDto>> CreateAsync(DestinationCreateDto dto);

        Task<ResponseDto<DestinationDto>> EditAsync(DestinationEditDto dto, Guid id);

        Task<ResponseDto<DestinationDto>> DeleteAsync(Guid id);
    }
}
