using AutoMapper;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.Destinations;
using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Dtos.TravelPackages;

namespace ProyectoViajes.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForAgencies();
            MapsForDestinations();
            MapsForPointsInterest();
            MapsForTravelPackages();
            MapsForActivities();
        }

        // Mapper de Agencias
        private void MapsForAgencies()
        {
            CreateMap<AgencyEntity, AgencyDto>();
            CreateMap<AgencyCreateDto, AgencyEntity>();
            CreateMap<AgencyEditDto, AgencyEntity>();
        }

        // Mapper de Destinos
        private void MapsForDestinations()
        {
            CreateMap<DestinationEntity, DestinationDto>()
                .ForMember(dest => dest.PointsInterest, opt => opt.MapFrom(src => src.PointsInterest))
                .ForMember(dest => dest.TravelPackages, opt => opt.MapFrom(src => src.TravelPackages));
            CreateMap<DestinationCreateDto, DestinationEntity>();
            CreateMap<DestinationEditDto, DestinationEntity>();
        }

        // Mapper de Puntos de interes
        private void MapsForPointsInterest()
        {
            CreateMap<PointInterestEntity, PointInterestDto>();
            CreateMap<PointInterestCreateDto, PointInterestEntity>();
            CreateMap<PointInterestEditDto, PointInterestEntity>();
        }

        // Mapper de Paquetes de viaje
        private void MapsForTravelPackages()
        {
            CreateMap<TravelPackageEntity, TravelPackageDto>()
                .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities))
                .ForMember(dest => dest.Agency, opt => opt.MapFrom(src => src.Agency))
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.Destination));
            CreateMap<TravelPackageCreateDto, TravelPackageEntity>();
            CreateMap<TravelPackageEditDto, TravelPackageEntity>();
        }

        // Maper de Actividades
        private void MapsForActivities()
        {
            CreateMap<ActivityEntity, ActivityDto>()
                .ForMember(dest => dest.TravelPackage, opt => opt.MapFrom(src => src.TravelPackage));
            CreateMap<ActivityCreateDto, ActivityEntity>();
            CreateMap<ActivityEditDto, ActivityEntity>();
        }
    }
}