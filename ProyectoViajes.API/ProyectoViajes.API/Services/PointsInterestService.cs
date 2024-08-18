using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class PointsInterestService : IPointsInterestService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;
        private readonly int PAGE_SIZE;

        public PointsInterestService(ProyectoViajesContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
        }

        public async Task<ResponseDto<PaginationDto<List<PointInterestDto>>>> GetPuntosDeInteresListAsync(string searchTerm = "", int page = 1)
        {
            int startIndex = (page - 1) * PAGE_SIZE;

            var pointsQuery = _context.PointsInterest.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                pointsQuery = pointsQuery
                    .Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            int totalPoints = await pointsQuery.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalPoints / PAGE_SIZE);

            var points = await pointsQuery
                .OrderByDescending(p => p.Name)
                .Skip(startIndex)
                .Take(PAGE_SIZE)
                .ToListAsync();

            var pointsDto = _mapper.Map<List<PointInterestDto>>(points);

            return new ResponseDto<PaginationDto<List<PointInterestDto>>>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = new PaginationDto<List<PointInterestDto>>
                {
                    CurrentPage = page,
                    PageSize = PAGE_SIZE,
                    TotalItems = totalPoints,
                    Items = pointsDto,
                    HasPreviousPage = page > 1,
                    HasNextPage = page < totalPages
                }
            };
        }

        public async Task<ResponseDto<PointInterestDto>> GetPuntoDeInteresByIdAsync(Guid id)
        {
            var pointsEntity = await _context.PointsInterest.FirstOrDefaultAsync(p => p.Id == id);

            if(pointsEntity == null){
                return new ResponseDto<PointInterestDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var pointsDto = _mapper.Map<PointInterestDto>(pointsEntity);

            return new ResponseDto<PointInterestDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = pointsDto
            };
        }

        public async Task<ResponseDto<PointInterestDto>> CreatePuntoDeInteresAsync(PointInterestCreateDto dto)
        {
            var pointsEntity = _mapper.Map<PointInterestEntity>(dto);

            _context.PointsInterest.Add(pointsEntity);

            await _context.SaveChangesAsync();

            var pointsDto = _mapper.Map<PointInterestDto>(pointsEntity);

            return new ResponseDto<PointInterestDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = pointsDto
            };
        }

        public async Task<ResponseDto<PointInterestDto>> EditPuntoDeInteresAsync(PointInterestEditDto dto, Guid id)
        {
            var pointsEntity = await _context.PointsInterest.FirstOrDefaultAsync(p => p.Id == id);

            if(pointsEntity == null){
                return new ResponseDto<PointInterestDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, pointsEntity);

            _context.PointsInterest.Update(pointsEntity);

            await _context.SaveChangesAsync();

            var pointsDto = _mapper.Map<PointInterestDto>(pointsEntity);

            return new ResponseDto<PointInterestDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = pointsDto
            };
        }

        public async Task<ResponseDto<PointInterestDto>> DeletePuntoDeInteresAsync(Guid id)
        {
            var pointsEntity = await _context.PointsInterest.FirstOrDefaultAsync(p => p.Id == id);

            if(pointsEntity == null){
                return new ResponseDto<PointInterestDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.PointsInterest.Remove(pointsEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<PointInterestDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}