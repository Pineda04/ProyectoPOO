using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Reservations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public ReservationsService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ReservationDto>>> GetReservationsListAsync()
        {
            var reservationsEntity = await _context.Reservations.ToListAsync();

            var reservationsDto = _mapper.Map<List<ReservationDto>>(reservationsEntity);

            return new ResponseDto<List<ReservationDto>>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = reservationsDto
            };
        }

        public async Task<ResponseDto<ReservationDto>> GetReservationByIdAsync(Guid id)
        {
            var reservationsEntity = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if(reservationsEntity == null){
                return new ResponseDto<ReservationDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var reservationsDto = _mapper.Map<ReservationDto>(reservationsEntity);

            return new ResponseDto<ReservationDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = reservationsDto
            };
        }

        public async Task<ResponseDto<ReservationDto>> CreateReservationAsync(ReservationCreateDto dto)
        {
            var reservationsEntity = _mapper.Map<ReservationEntity>(dto);

            _context.Reservations.Add(reservationsEntity);

            await _context.SaveChangesAsync();

            var reservationsDto = _mapper.Map<ReservationDto>(reservationsEntity);

            return new ResponseDto<ReservationDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = reservationsDto
            };
        }

        public async Task<ResponseDto<ReservationDto>> EditReservationAsync(ReservationEditDto dto, Guid id)
        {
            var reservationsEntity = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if(reservationsEntity == null){
                return new ResponseDto<ReservationDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, reservationsEntity);

            _context.Reservations.Update(reservationsEntity);

            await _context.SaveChangesAsync();

            var reservationsDto = _mapper.Map<ReservationDto>(reservationsEntity);

            return new ResponseDto<ReservationDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = reservationsDto
            };
        }

        public async Task<ResponseDto<ReservationDto>> DeleteReservationAsync(Guid id)
        {
            var reservationsEntity = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if(reservationsEntity == null){
                return new ResponseDto<ReservationDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Reservations.Remove(reservationsEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<ReservationDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}