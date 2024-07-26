using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class AgenciesService : IAgenciesService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public AgenciesService(ProyectoViajesContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<AgencyDto>>> GetAgenciesListAsync()
        {
            var agenciesEntity = await _context.Agencies.ToListAsync();
            var agenciesDtos = _mapper.Map<List<AgencyDto>>(agenciesEntity);

            return new ResponseDto<List<AgencyDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de agencias obtenidos correctamente",
                Data = agenciesDtos
            };
        }

        public async Task<ResponseDto<AgencyDto>> GetAgencyByIdAsync(Guid id)
        {
            var agencyEntity = await _context.Agencies.FirstOrDefaultAsync(e => e.Id == id);

            if(agencyEntity == null)
            {
                return new ResponseDto<AgencyDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro la agencia"
                };
            }

            var agencyDto = _mapper.Map<AgencyDto>(agencyEntity);

            return new ResponseDto<AgencyDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado correctamente",
                Data = agencyDto
            };
        }

        public async Task<ResponseDto<AgencyDto>> CreateAsync(AgencyCreateDto dto)
        {
            var agencyEntity = _mapper.Map<AgencyEntity>(dto);

            _context.Agencies.Add(agencyEntity);

            await _context.SaveChangesAsync();

            var agencyDto = _mapper.Map<AgencyDto>(agencyEntity);

            return new ResponseDto<AgencyDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Registro creado exitosamente",
                Data= agencyDto
            };
        }

        public async Task<ResponseDto<AgencyDto>> EditAsync(AgencyEditDto dto, Guid id)
        {
            var agencyEntity = await _context.Agencies.FirstOrDefaultAsync(e => e.Id == id);

            if(agencyEntity == null)
            {
                return new ResponseDto<AgencyDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el registro"
                };
            }

            _mapper.Map<AgencyEditDto, AgencyEntity>(dto, agencyEntity);

            _context.Agencies.Update(agencyEntity);

            await _context.SaveChangesAsync();

            var agencyDto = _mapper.Map<AgencyDto>(agencyEntity);

            return new ResponseDto<AgencyDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro modificado exitosamente",
                Data = agencyDto
            };
        }

        public async Task<ResponseDto<AgencyDto>> DeleteAsync(Guid id)
        {
            var agencyEntity = await _context.Agencies.FirstOrDefaultAsync(c => c.Id == id);

            if (agencyEntity == null)
            {
                return new ResponseDto<AgencyDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el registro"
                };
            }

            _context.Agencies.Remove(agencyEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<AgencyDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro borrado correctamente"
            };
        }
    }
}
