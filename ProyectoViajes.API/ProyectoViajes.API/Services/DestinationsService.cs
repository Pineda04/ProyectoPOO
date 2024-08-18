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
        private readonly int PAGE_SIZE;

        public DestinationsService(ProyectoViajesContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
        }

        public async Task<ResponseDto<PaginationDto<List<DestinationDto>>>> GetDestinationsListAsync(string searchTerm = "", int page = 1)
        {
            int startIndex = (page - 1) * PAGE_SIZE;

            var destinationsQuery = _context.Destinations
                .Include(d => d.PointsInterest)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                destinationsQuery = destinationsQuery
                    .Where(d => d.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                d.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            int totalDestinations = await destinationsQuery.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalDestinations / PAGE_SIZE);

            var destinations = await destinationsQuery
                .OrderBy(d => d.Name) // Or any other sorting criteria
                .Skip(startIndex)
                .Take(PAGE_SIZE)
                .ToListAsync();

            var destinationDtos = _mapper.Map<List<DestinationDto>>(destinations);

            return new ResponseDto<PaginationDto<List<DestinationDto>>>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = new PaginationDto<List<DestinationDto>>
                {
                    CurrentPage = page,
                    PageSize = PAGE_SIZE,
                    TotalItems = totalDestinations,
                    Items = destinationDtos,
                    HasPreviousPage = page > 1,
                    HasNextPage = page < totalPages
                }
            };
        }


        public async Task<ResponseDto<DestinationDto>> GetDestinationByIdAsync(Guid id)
        {
            var destinationEntity = await _context.Destinations.Include(d => d.PointsInterest).FirstOrDefaultAsync(d => d.Id == id);

            if (destinationEntity == null)
            {
                return new ResponseDto<DestinationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>
            {
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

            return new ResponseDto<DestinationDto>
            {
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> EditDestinationAsync(DestinationEditDto dto, Guid id)
        {
            var destinationEntity = await _context.Destinations.Include(d => d.PointsInterest).FirstOrDefaultAsync(d => d.Id == id);

            if (destinationEntity == null)
            {
                return new ResponseDto<DestinationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, destinationEntity);

            _context.Destinations.Update(destinationEntity);

            await _context.SaveChangesAsync();

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> DeleteDestinationAsync(Guid id)
        {
            var destinationEntity = await _context.Destinations.FirstOrDefaultAsync(d => d.Id == id);

            if (destinationEntity == null)
            {
                return new ResponseDto<DestinationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Destinations.Remove(destinationEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<DestinationDto>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}