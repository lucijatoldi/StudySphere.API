namespace StudySphere.API.DTOs
{
    public class CreateReservationDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StudyRoomId { get; set; }
        public int UserId { get; set; }
    }
}