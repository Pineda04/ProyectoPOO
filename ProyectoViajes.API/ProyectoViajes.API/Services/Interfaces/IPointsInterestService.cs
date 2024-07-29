using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Dtos.Common;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IPointsInterestService
    {
        Task<ResponseDto<List<PointInterestDto>>> GetPointsInterestListAsync();

        Task<ResponseDto<PointInterestDto>> GetPointInterestByIdAsync(Guid id);

        Task<ResponseDto<PointInterestDto>> CreateAsync(PointInterestCreateDto dto);

        Task<ResponseDto<PointInterestDto>> EditAsync(PointInterestEditDto dto, Guid id);

        Task<ResponseDto<PointInterestDto>> DeleteAsync(Guid id);
    }
}
