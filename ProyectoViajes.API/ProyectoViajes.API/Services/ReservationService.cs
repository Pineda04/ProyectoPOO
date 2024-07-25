using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Dtos.Reservations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{

    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<ReservationDto>>> GetReservationsListAsync()
        {
            var reservations = await _context.Reservations
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    PackageId = r.PackageId,
                    ReservationDate = r.ReservationDate,
                    Status = r.Status,
                    TotalPaid = r.TotalPaid
                }).ToListAsync();

            return new ResponseDto<List<ReservationDto>>
            {
                StatusCode = 200,
                Status = true,
                Data = reservations,
                Message = "Success",
               
            };
        }

        public async Task<ResponseDto<ReservationDto>> GetReservationByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return new ResponseDto<ReservationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Reservation not found",
                    
                };
            }

            var reservationDto = new ReservationDto
            {
                Id = reservation.Id,
                UserId = reservation.UserId,
                PackageId = reservation.PackageId,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                TotalPaid = reservation.TotalPaid
            };

            return new ResponseDto<ReservationDto>
            {
                StatusCode = 200,
                Status = true,
                Data = reservationDto,
                Message = "Success",
               
            };
        }

        public async Task<ResponseDto<ReservationDto>> CreateAsync(CreateReservationDto dto)
        {
            var reservation = new ReservationDto
            {
                UserId = dto.UserId,
                PackageId = dto.PackageId,
                ReservationDate = dto.ReservationDate,
                Status = dto.Status,
                TotalPaid = dto.TotalPaid
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            var reservationDto = new ReservationDto
            {
                Id = reservation.Id,
                UserId = reservation.UserId,
                PackageId = reservation.PackageId,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                TotalPaid = reservation.TotalPaid
            };

            return new ResponseDto<ReservationDto>
            {
                StatusCode = 201,
                Status = true,
                Data = reservationDto,
                Message = "Reservation created successfully",
                 
            };
        }

        public async Task<ResponseDto<ReservationDto>> EditAsync(EditReservationDto dto, int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return new ResponseDto<ReservationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Reservation not found",
                   
                };
            }

            reservation.UserId = dto.UserId;
            reservation.PackageId = dto.PackageId;
            reservation.ReservationDate = dto.ReservationDate;
            reservation.Status = dto.Status;
            reservation.TotalPaid = dto.TotalPaid;

            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();

            var reservationDto = new ReservationDto
            {
                Id = reservation.Id,
                UserId = reservation.UserId,
                PackageId = reservation.PackageId,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,
                TotalPaid = reservation.TotalPaid
            };

            return new ResponseDto<ReservationDto>
            {
                StatusCode = 200,
                Status = true,
                Data = reservationDto,
                Message = "Reservation updated successfully",
               
            };
        }

        public async Task<ResponseDto<ReservationDto>> DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return new ResponseDto<ReservationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Reservation not found",
                    
                };
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return new ResponseDto<ReservationDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Reservation deleted successfully",
               
            };
        }
    }
}
