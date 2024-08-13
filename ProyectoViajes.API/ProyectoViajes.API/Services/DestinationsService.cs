using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.Destinations;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class DestinationsService : IDestinationsService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public DestinationsService(ProyectoViajesContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        
        public async Task<ResponseDto<List<DestinationDto>>> GetDestinationsListAsync()
        {
            var destinationsEntity = await _context.Destinations.Include(d => d.PointsInterest).ToListAsync();
            var destinationsDto = _mapper.Map<List<DestinationDto>>(destinationsEntity);

            return new ResponseDto<List<DestinationDto>> {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = destinationsDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> GetDestinationByIdAsync(Guid id)
        {
            var destinationEntity = await _context.Destinations.Include(d => d.PointsInterest).FirstOrDefaultAsync(d => d.Id == id);
        
            if(destinationEntity == null){
                return new ResponseDto<DestinationDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> CreateDestinationAsync(DestinationCreateDto dto)
        {
            var destinationEntity = _mapper.Map<DestinationEntity>(dto);

            _context.Destinations.Add(destinationEntity);

            await _context.SaveChangesAsync();

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> EditDestinationAsync(DestinationEditDto dto, Guid id)
        {
            var destinationEntity = await _context.Destinations.Include(d => d.PointsInterest).FirstOrDefaultAsync(d => d.Id == id);

            if(destinationEntity == null){
                return new ResponseDto<DestinationDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, destinationEntity);

            _context.Destinations.Update(destinationEntity);

            await _context.SaveChangesAsync();

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = destinationDto
            };  
        }

        public async Task<ResponseDto<DestinationDto>> DeleteDestinationAsync(Guid id)
        {
            var destinationEntity = await _context.Destinations.FirstOrDefaultAsync(d => d.Id == id);

            if(destinationEntity == null){
                return new ResponseDto<DestinationDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Destinations.Remove(destinationEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<DestinationDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}