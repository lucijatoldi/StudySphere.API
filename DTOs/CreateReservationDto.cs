using System.ComponentModel;

namespace StudySphere.API.DTOs
{
    public class CreateReservationDto
    {
        [DefaultValue("2025-11-25T10:00:00")]
        public DateTime StartTime { get; set; }
        [DefaultValue("2025-11-25T11:00:00")]
        public DateTime EndTime { get; set; }
        [DefaultValue(1)]
        public int StudyRoomId { get; set; }
        [DefaultValue(1)]
        public int UserId { get; set; }
    }
}