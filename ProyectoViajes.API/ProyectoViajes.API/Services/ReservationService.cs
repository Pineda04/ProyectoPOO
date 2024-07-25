using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Dtos.Reservations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{

    public class ReservationService : IReservationService
    {
        public Task<ResponseDto<List<ReservationDto>>> GetReservationsListAsync()
        {
             
        }

        public Task<ResponseDto<ReservationDto>> GetReservationByIdAsync(int id)
        {
             
        }

        public Task<ResponseDto<ReservationDto>> CreateAsync(CreateReservationDto dto)
        {
             
        }

        public Task<ResponseDto<ReservationDto>> EditAsync(EditReservationDto dto, int id)
        {
            
        }

        public Task<ResponseDto<ReservationDto>> DeleteAsync(int id)
        {
             
        }
    }
}
