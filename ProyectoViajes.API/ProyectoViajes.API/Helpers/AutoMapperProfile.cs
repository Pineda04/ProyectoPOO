using AutoMapper;
using ProyectoViajes.API.Database.Entities;
using ProyectoViajes.API.Dtos.Activities;
using ProyectoViajes.API.Dtos.Agencies;
using ProyectoViajes.API.Dtos.Assessments;
using ProyectoViajes.API.Dtos.Destinations;
using ProyectoViajes.API.Dtos.Payments;
using ProyectoViajes.API.Dtos.PointsInterest;
using ProyectoViajes.API.Dtos.Reservations;
using ProyectoViajes.API.Dtos.TravelPackages;
using ProyectoViajes.API.Dtos.Users;

namespace ProyectoViajes.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForAgencies();
            MapsForDestinations();
            MappForPointsInterest();
            MappForTravelPackages();
            MappForActivities();
            MappForAssessments();
            MappForReservations();
            MappForUsers();
            MapsForPayments();
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
            .ForMember(dest => dest.PointsInterest, opt => opt.MapFrom(src => src.PointsInterest));
            CreateMap<DestinationCreateDto, DestinationEntity>();
            CreateMap<DestinationEditDto, DestinationEntity>();
        }

        // Mapper de Puntos de interes
        private void MappForPointsInterest()
        {
            CreateMap<PointInterestEntity, PointInterestDto>();
            CreateMap<PointInterestCreateDto, PointInterestEntity>();
            CreateMap<PointInterestEditDto, PointInterestEntity>();
        }

        // Mapper de los paquetes de viaje
        private void MappForTravelPackages()
        {
            CreateMap<TravelPackageEntity, TravelPackageDto>()
            .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities));
            CreateMap<TravelPackageCreateDto, TravelPackageEntity>();
            CreateMap<TravelPackageEditDto, TravelPackageEntity>();
        }

        // Mapper de las actividades
        private void MappForActivities()
        {
            CreateMap<ActivityEntity, ActivityDto>();
            CreateMap<ActivityCreateDto, ActivityEntity>();
            CreateMap<ActivityEditDto, ActivityEntity>();
        }

        // Mapper de las valoraciones
        private void MappForAssessments()
        {
            CreateMap<AssessmentEntity, AssessmentDto>();
            CreateMap<AssessmentCreateDto, AssessmentEntity>();
            CreateMap<AssessmentEditDto, AssessmentEntity>();
        }

        // Mapper de las reservaciones
        private void MappForReservations()
        {
            CreateMap<ReservationEntity, ReservationDto>();
            CreateMap<ReservationCreateDto, ReservationEntity>();
            CreateMap<ReservationEditDto, ReservationEntity>();
        }

        // Mapper del Usuario
        private void MappForUsers()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserCreateDto, UserEntity>();
            CreateMap<UserEditDto, UserEntity>();
        }

        // Mapper de los pagos
        private void MapsForPayments()
        {
            CreateMap<PaymentEntity, PaymentDto>();
            CreateMap<PaymentCreateDto, PaymentEntity>();
            CreateMap<PaymentEditDto, PaymentEntity>();
        }
    }
}