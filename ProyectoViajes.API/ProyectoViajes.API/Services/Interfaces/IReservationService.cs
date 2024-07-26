using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Reservations;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ResponseDto<List<ReservationDto>>> GetReservationsListAsync();
        Task<ResponseDto<ReservationDto>> GetReservationByIdAsync(Guid id);
        Task<ResponseDto<ReservationDto>> CreateAsync(CreateReservationDto dto);
        Task<ResponseDto<ReservationDto>> EditAsync(EditReservationDto dto, Guid id);
        Task<ResponseDto<ReservationDto>> DeleteAsync(Guid id);
    }
}
