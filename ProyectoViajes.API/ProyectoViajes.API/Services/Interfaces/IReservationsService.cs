using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Reservations;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IReservationsService
    {
        Task<ResponseDto<List<ReservationDto>>> GetReservationsListAsync();

        Task<ResponseDto<ReservationDto>> GetReservationByIdAsync(Guid id);

        Task<ResponseDto<ReservationDto>> CreateReservationAsync(ReservationCreateDto dto);

        Task<ResponseDto<ReservationDto>> EditReservationAsync(ReservationEditDto dto, Guid id);

        Task<ResponseDto<ReservationDto>> DeleteReservationAsync(Guid id);
    }
}