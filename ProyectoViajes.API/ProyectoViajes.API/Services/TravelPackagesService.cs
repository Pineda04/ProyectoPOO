using AutoMapper;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.TravelPackages;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class TravelPackagesService : ITravelPackagesService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public TravelPackagesService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<TravelPackageDto>>> GetTravelPackagesListAsync()
        {
            var travelPackagesEntity = await _context.TravelPackages
                .Include(tp => tp.Agency)
                .Include(tp => tp.Destination)
                .Include(tp => tp.Activities)
                .ToListAsync();

            var travelPackagesDtos = _mapper.Map<List<TravelPackageDto>>(travelPackagesEntity);

            return new ResponseDto<List<TravelPackageDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de paquetes de viaje obtenida correctamente",
                Data = travelPackagesDtos
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> GetTravelPackageByIdAsync(Guid id)
        {
            var travelPackageEntity = await _context.TravelPackages
                .Include(tp => tp.Agency)
                .Include(tp => tp.Destination)
                .Include(tp => tp.Activities)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (travelPackageEntity == null)
            {
                return new ResponseDto<TravelPackageDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el paquete de viaje"
                };
            }

            var travelPackageDto = _mapper.Map<TravelPackageDto>(travelPackageEntity);

            return new ResponseDto<TravelPackageDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado correctamente",
                Data = travelPackageDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> CreateAsync(TravelPackageCreateDto dto)
        {
            var travelPackageEntity = _mapper.Map<TravelPackageEntity>(dto);

            _context.TravelPackages.Add(travelPackageEntity);
            await _context.SaveChangesAsync();

            var travelPackageDto = _mapper.Map<TravelPackageDto>(travelPackageEntity);

            return new ResponseDto<TravelPackageDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Registro creado exitosamente",
                Data = travelPackageDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> EditAsync(TravelPackageEditDto dto, Guid id)
        {
            var travelPackageEntity = await _context.TravelPackages
                .Include(tp => tp.Activities)
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (travelPackageEntity == null)
            {
                return new ResponseDto<TravelPackageDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _mapper.Map(dto, travelPackageEntity);

            _context.TravelPackages.Update(travelPackageEntity);
            await _context.SaveChangesAsync();

            var travelPackageDto = _mapper.Map<TravelPackageDto>(travelPackageEntity);

            return new ResponseDto<TravelPackageDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro modificado exitosamente",
                Data = travelPackageDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> DeleteAsync(Guid id)
        {
            var travelPackageEntity = await _context.TravelPackages
                .FirstOrDefaultAsync(tp => tp.Id == id);

            if (travelPackageEntity == null)
            {
                return new ResponseDto<TravelPackageDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró el registro"
                };
            }

            _context.TravelPackages.Remove(travelPackageEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<TravelPackageDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro borrado correctamente"
            };
        }
    }
}
