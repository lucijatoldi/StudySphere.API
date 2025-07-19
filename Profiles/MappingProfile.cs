using AutoMapper;
using StudySphere.API.DTOs;
using StudySphere.API.Models;

namespace StudySphere.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapa: Izvor -> Odredište
            CreateMap<StudyRoom, StudyRoomDto>();
            CreateMap<User, UserDto>();
            CreateMap<Reservation, ReservationDto>();
        }
    }
}
