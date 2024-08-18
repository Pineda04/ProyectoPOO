using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.PointsInterest;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IPointsInterestService
    {
        Task<ResponseDto<PaginationDto<List<PointInterestDto>>>> GetPuntosDeInteresListAsync(string searchTerm = "", int page = 1);
        Task<ResponseDto<PointInterestDto>> GetPuntoDeInteresByIdAsync(Guid id);
        Task<ResponseDto<PointInterestDto>> CreatePuntoDeInteresAsync(PointInterestCreateDto dto);
        Task<ResponseDto<PointInterestDto>> EditPuntoDeInteresAsync(PointInterestEditDto dto, Guid id);
        Task<ResponseDto<PointInterestDto>> DeletePuntoDeInteresAsync(Guid id);
    }
}