using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Services.Interfaces;

namespace ProyectoViajes.API.Services
{
    public class AgenciesService : IAgenciesService
    {
        private readonly ProyectoViajesContext _context;
        private readonly IMapper _mapper;

        public AgenciesService(ProyectoViajesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Traer todo
        public async Task<ResponseDto<List<AgencyDto>>> GetAgenciesListAsync()
        {
            var agenciesEntity = await _context.Agencies.ToListAsync();
            
            var agenciesDtos = _mapper.Map<List<AgencyDto>>(agenciesEntity);

            return new ResponseDto<List<AgencyDto>>{
              StatusCode = 200,
              Status = true,
              Message = MessagesConstant.RECORDS_FOUND,  
              Data = agenciesDtos
            };
        }

        // Traer por Id
        public async Task<ResponseDto<AgencyDto>> GetAgencyByIdAsync(Guid id)
        {
            var agencyEntity = await _context.Agencies.FirstOrDefaultAsync(a => a.Id == id);

            if(agencyEntity == null){
                return new ResponseDto<AgencyDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var agencyDto = _mapper.Map<AgencyDto>(agencyEntity);

            return new ResponseDto<AgencyDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = agencyDto
            };
        }

        // Crear
        public async Task<ResponseDto<AgencyDto>> CreateAgencyAsync(AgencyCreateDto dto)
        {
            var agencyEntity = _mapper.Map<AgencyEntity>(dto);
            agencyEntity.RegistrationDate = DateTime.UtcNow;

            _context.Agencies.Add(agencyEntity);

            await _context.SaveChangesAsync();

            var agencyDto = _mapper.Map<AgencyDto>(agencyEntity);

            return new ResponseDto<AgencyDto>{
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = agencyDto
            };
        }

        // Editar
        public async Task<ResponseDto<AgencyDto>> EditAgencyAsync(AgencyEditDto dto, Guid id)
        {
            var agencyEntity = await _context.Agencies.FirstOrDefaultAsync(a => a.Id == id);

            if(agencyEntity == null){
                return new ResponseDto<AgencyDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            }

            _mapper.Map(dto, agencyEntity);

            _context.Agencies.Update(agencyEntity);

            await _context.SaveChangesAsync();

            var agencyDto = _mapper.Map<AgencyDto>(agencyEntity);

            return new ResponseDto<AgencyDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = agencyDto
            };
        }

        // ELiminar
        public async Task<ResponseDto<AgencyDto>> DeleteAgencyAsync(Guid id)
        {
            var agencyEntity = await _context.Agencies.FirstOrDefaultAsync(a => a.Id == id);

            if(agencyEntity == null){
                return new ResponseDto<AgencyDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.Agencies.Remove(agencyEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<AgencyDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS
            };
        }
    }
}