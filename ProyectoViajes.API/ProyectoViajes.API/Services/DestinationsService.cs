using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Destinations;
using ProyectoViajes.API.Dtos.Common;
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
            var destinationsEntity = await _context.Destinations.ToListAsync();
            var destinationsDtos = _mapper.Map<List<DestinationDto>>(destinationsEntity);

            return new ResponseDto<List<DestinationDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de destinos obtenidos correctamente",
                Data = destinationsDtos
            };
        }

        public async Task<ResponseDto<DestinationDto>> GetDestinationByIdAsync(Guid id)
        {
            var destinationEntity = await _context.Destinations.FirstOrDefaultAsync(e => e.Id == id);

            if (destinationEntity == null)
            {
                return new ResponseDto<DestinationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el destino"
                };
            }

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado correctamente",
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> CreateAsync(DestinationCreateDto dto)
        {
            var destinationEntity = _mapper.Map<DestinationEntity>(dto);

            _context.Destinations.Add(destinationEntity);
            await _context.SaveChangesAsync();

            var destinationDto = _mapper.Map<DestinationDto>(destinationEntity);

            return new ResponseDto<DestinationDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Registro creado exitosamente",
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> EditAsync(DestinationEditDto dto, Guid id)
        {
            var destinationEntity = await _context.Destinations.FirstOrDefaultAsync(e => e.Id == id);

            if (destinationEntity == null)
            {
                return new ResponseDto<DestinationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
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
                Message = "Registro modificado exitosamente",
                Data = destinationDto
            };
        }

        public async Task<ResponseDto<DestinationDto>> DeleteAsync(Guid id)
        {
            var destinationEntity = await _context.Destinations.FirstOrDefaultAsync(e => e.Id == id);

            if (destinationEntity == null)
            {
                return new ResponseDto<DestinationDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _context.Destinations.Remove(destinationEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<DestinationDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro borrado correctamente"
            };
        }
    }
}
