using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Dtos.Reservations;

namespace ProyectoViajes.API.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ResponseDto<List<ReservationDto>>> GetReservationsListAsync();
        Task<ResponseDto<ReservationDto>> GetReservationByIdAsync(int id);
        Task<ResponseDto<ReservationDto>> CreateAsync(CreateReservationDto dto);
        Task<ResponseDto<ReservationDto>> EditAsync(EditReservationDto dto, int id);
        Task<ResponseDto<ReservationDto>> DeleteAsync(int id);
    }
}
