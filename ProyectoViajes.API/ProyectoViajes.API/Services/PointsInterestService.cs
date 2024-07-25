using AutoMapper;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProyectoViajes.API.Services
{
    public class PointsInterestService : IPointsInterestService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public PointsInterestService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<PointInterestDto>>> GetPointsInterestListAsync()
        {
            var pointsInterestsEntity = await _context.PointsInterest.ToListAsync();
            var pointsInterestsDtos = _mapper.Map<List<PointInterestDto>>(pointsInterestsEntity);

            return new ResponseDto<List<PointInterestDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de puntos de interés obtenidos correctamente",
                Data = pointsInterestsDtos
            };
        }

        public async Task<ResponseDto<PointInterestDto>> GetPointInterestByIdAsync(Guid id)
        {
            var pointInterestEntity = await _context.PointsInterest.FirstOrDefaultAsync(e => e.Id == id);

            if (pointInterestEntity == null)
            {
                return new ResponseDto<PointInterestDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el punto de interés"
                };
            }

            var pointInterestDto = _mapper.Map<PointInterestDto>(pointInterestEntity);

            return new ResponseDto<PointInterestDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado correctamente",
                Data = pointInterestDto
            };
        }

        public async Task<ResponseDto<PointInterestDto>> CreateAsync(PointInterestCreateDto dto)
        {
            var pointInterestEntity = _mapper.Map<PointInterestEntity>(dto);

            _context.PointsInterest.Add(pointInterestEntity);
            await _context.SaveChangesAsync();

            var pointInterestDto = _mapper.Map<PointInterestDto>(pointInterestEntity);

            return new ResponseDto<PointInterestDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Registro creado exitosamente",
                Data = pointInterestDto
            };
        }

        public async Task<ResponseDto<PointInterestDto>> EditAsync(PointInterestEditDto dto, Guid id)
        {
            var pointInterestEntity = await _context.PointsInterest.FirstOrDefaultAsync(e => e.Id == id);

            if (pointInterestEntity == null)
            {
                return new ResponseDto<PointInterestDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _mapper.Map(dto, pointInterestEntity);

            _context.PointsInterest.Update(pointInterestEntity);
            await _context.SaveChangesAsync();

            var pointInterestDto = _mapper.Map<PointInterestDto>(pointInterestEntity);

            return new ResponseDto<PointInterestDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro modificado exitosamente",
                Data = pointInterestDto
            };
        }

        public async Task<ResponseDto<PointInterestDto>> DeleteAsync(Guid id)
        {
            var pointInterestEntity = await _context.PointsInterest.FirstOrDefaultAsync(e => e.Id == id);

            if (pointInterestEntity == null)
            {
                return new ResponseDto<PointInterestDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _context.PointsInterest.Remove(pointInterestEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<PointInterestDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro borrado correctamente"
            };
        }
    }
}
