using AutoMapper;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Agencies;

namespace ProyectoViajes.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            MapsForAgencies();
        }

        // Mapper de Agencias
        private void MapsForAgencies()
        {
            CreateMap<AgencyEntity, AgencyDto>();
            CreateMap<AgencyCreateDto, AgencyEntity>();
            CreateMap<AgencyEditDto, AgencyEntity>();
        }
    }
}
