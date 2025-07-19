namespace StudySphere.API.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public StudyRoomDto StudyRoom { get; set; }
        public UserDto User { get; set; }

    }
}
