using AutoMapper;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Dtos.common;

namespace ProyectoViajes.API.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public ActivitiesService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<ActivityDto>>> GetActivitiesListAsync()
        {
            var activitiesEntity = await _context.Activities
                .Include(a => a.TravelPackage)
                .ToListAsync();

            var activitiesDtos = _mapper.Map<List<ActivityDto>>(activitiesEntity);

            return new ResponseDto<List<ActivityDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de actividades obtenida correctamente",
                Data = activitiesDtos
            };
        }

        public async Task<ResponseDto<ActivityDto>> GetActivityByIdAsync(Guid id)
        {
            var activityEntity = await _context.Activities
                .Include(a => a.TravelPackage)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (activityEntity == null)
            {
                return new ResponseDto<ActivityDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró la actividad"
                };
            }

            var activityDto = _mapper.Map<ActivityDto>(activityEntity);

            return new ResponseDto<ActivityDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado correctamente",
                Data = activityDto
            };
        }

        public async Task<ResponseDto<ActivityDto>> CreateAsync(ActivityCreateDto dto)
        {
            var activityEntity = _mapper.Map<ActivityEntity>(dto);

            _context.Activities.Add(activityEntity);
            await _context.SaveChangesAsync();

            var activityDto = _mapper.Map<ActivityDto>(activityEntity);

            return new ResponseDto<ActivityDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Registro creado exitosamente",
                Data = activityDto
            };
        }

        public async Task<ResponseDto<ActivityDto>> EditAsync(ActivityEditDto dto, Guid id)
        {
            var activityEntity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id);

            if (activityEntity == null)
            {
                return new ResponseDto<ActivityDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _mapper.Map(dto, activityEntity);

            _context.Activities.Update(activityEntity);
            await _context.SaveChangesAsync();

            var activityDto = _mapper.Map<ActivityDto>(activityEntity);

            return new ResponseDto<ActivityDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro modificado exitosamente",
                Data = activityDto
            };
        }

        public async Task<ResponseDto<ActivityDto>> DeleteAsync(Guid id)
        {
            var activityEntity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id);

            if (activityEntity == null)
            {
                return new ResponseDto<ActivityDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _context.Activities.Remove(activityEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<ActivityDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro borrado correctamente"
            };
        }
    }
}
