using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.TravelPackages;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface ITravelPackagesService
    {
        Task<ResponseDto<PaginationDto<List<TravelPackageDto>>>> GetTravelPackagesListAsync(string searchTerm = "", int page = 1);

        Task<ResponseDto<TravelPackageDto>> GetTravelPackageByIdAsync(Guid id);

        Task<ResponseDto<TravelPackageDto>> CreateTravelPackageAsync(TravelPackageCreateDto dto);

        Task<ResponseDto<TravelPackageDto>> EditTravelPackageAsync(TravelPackageEditDto dto, Guid id);

        Task<ResponseDto<TravelPackageDto>> DeleteTravelPackageAsync(Guid id);
    }
}