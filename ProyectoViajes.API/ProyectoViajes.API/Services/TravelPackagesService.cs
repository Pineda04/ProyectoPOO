using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProyectoViajes.API.Constants;
using ProyectoViajes.API.Database;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Common;
using ProyectoViajes.API.Dtos.TravelPackages;
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
            var packagesEntity = await _context.TravelPackages.Include(tp => tp.Activities).ToListAsync();

            var packagesDto = _mapper.Map<List<TravelPackageDto>>(packagesEntity);

            return new ResponseDto<List<TravelPackageDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORDS_FOUND,
                Data = packagesDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> GetTravelPackageByIdAsync(Guid id)
        {
            var packagesEntity = await _context.TravelPackages.Include(tp => tp.Activities).FirstOrDefaultAsync(tp => tp.Id == id);

            if (packagesEntity == null)
            {
                return new ResponseDto<TravelPackageDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.RECORD_NOT_FOUND
                };
            }

            var packagesDto = _mapper.Map<TravelPackageDto>(packagesEntity);

            return new ResponseDto<TravelPackageDto>
            {
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.RECORD_FOUND,
                Data = packagesDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> CreateTravelPackageAsync(TravelPackageCreateDto dto)
        {
            var packagesEntity = _mapper.Map<TravelPackageEntity>(dto);

            _context.TravelPackages.Add(packagesEntity);

            await _context.SaveChangesAsync();

            var packagesDto = _mapper.Map<TravelPackageDto>(packagesEntity);

            return new ResponseDto<TravelPackageDto>
            {
                StatusCode = 201,
                Status = true,
                Message = MessagesConstant.CREATE_SUCCESS,
                Data = packagesDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> EditTravelPackageAsync(TravelPackageEditDto dto, Guid id)
        {
            var packagesEntity = await _context.TravelPackages.Include(tp => tp.Activities).FirstOrDefaultAsync(tp => tp.Id == id);

            if(packagesEntity == null){
                return new ResponseDto<TravelPackageDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.UPDATE_ERROR
                };
            };

            _mapper.Map(dto, packagesEntity);

            _context.TravelPackages.Update(packagesEntity);

            await _context.SaveChangesAsync();

            var packagesDto = _mapper.Map<TravelPackageDto>(packagesEntity);

            return new ResponseDto<TravelPackageDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.UPDATE_SUCCESS,
                Data = packagesDto
            };
        }

        public async Task<ResponseDto<TravelPackageDto>> DeleteTravelPackageAsync(Guid id)
        {
            var packagesEntity = await _context.TravelPackages.Include(tp => tp.Activities).FirstOrDefaultAsync(tp => tp.Id == id);
            
            if(packagesEntity == null){
                return new ResponseDto<TravelPackageDto>{
                    StatusCode = 404,
                    Status = false,
                    Message = MessagesConstant.DELETE_ERROR
                };
            }

            _context.TravelPackages.Remove(packagesEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<TravelPackageDto>{
                StatusCode = 200,
                Status = true,
                Message = MessagesConstant.DELETE_SUCCESS
            };
        }
    }
}