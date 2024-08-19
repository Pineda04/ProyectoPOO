using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;
        private readonly int PAGE_SIZE;

        public ActivitiesService(ProyectoViajesContext context, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
        }

        public async Task<ResponseDto<PaginationDto<List<ActivityDto>>>> GetActivitiesListAsync(string searchTerm = "", int page = 1)
        {
            int startIndex = (page - 1) * PAGE_SIZE;

            var activitiesQuery = _context.Activities.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                activitiesQuery = activitiesQuery
                    .Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                a.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            int totalActivities = await activitiesQuery.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalActivities / PAGE_SIZE);

            var activities = await activitiesQuery
                .OrderByDescending(a => a.Name) 
                .Skip(startIndex)
                .Take(PAGE_SIZE)
                .ToListAsync();

            var activitiesDto = _mapper.Map<List<ActivityDto>>(activities);

            return new ResponseDto<PaginationDto<List<ActivityDto>>>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = new PaginationDto<List<ActivityDto>>
                {
                    CurrentPage = page,
                    PageSize = PAGE_SIZE,
                    TotalItems = totalActivities,
                    Items = activitiesDto,
                    HasPreviousPage = page > 1,
                    HasNextPage = page < totalPages
                }
            };
        }

        public async Task<ResponseDto<ActivityDto>> GetActivityByIdAsync(Guid id)
        {
            var activitiesEntity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);

            if(activitiesEntity == null){
                return new ResponseDto<ActivityDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var activitiesDto = _mapper.Map<ActivityDto>(activitiesEntity);

            return new ResponseDto<ActivityDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = activitiesDto
            };
        }
        
        public async Task<ResponseDto<ActivityDto>> CreateActivityAsync(ActivityCreateDto dto)
        {
            var activitiesEntity = _mapper.Map<ActivityEntity>(dto);

            _context.Activities.Add(activitiesEntity);

            await _context.SaveChangesAsync();

            var activitiesDto = _mapper.Map<ActivityDto>(activitiesEntity);

            return new ResponseDto<ActivityDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = activitiesDto
            };
        }

        public async Task<ResponseDto<ActivityDto>> EditActivityAsync(ActivityEditDto dto, Guid id)
        {
            var activitiesEntity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);

            if(activitiesEntity == null){
                return new ResponseDto<ActivityDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR,
                };
            }

            _mapper.Map(dto, activitiesEntity);

            _context.Activities.Update(activitiesEntity);

            await _context.SaveChangesAsync();

            var activitiesDto = _mapper.Map<ActivityDto>(activitiesEntity);

            return new ResponseDto<ActivityDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = activitiesDto
            };
        }

        public async Task<ResponseDto<ActivityDto>> DeleteActivityAsync(Guid id)
        {
            var activitiesEntity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);

            if(activitiesEntity == null){
                return new ResponseDto<ActivityDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Activities.Remove(activitiesEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<ActivityDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}