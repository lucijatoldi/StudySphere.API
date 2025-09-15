using System.ComponentModel;

namespace StudySphere.API.DTOs
{
    public class CreateReservationDto
    {
        [DefaultValue("2026-10-15T09:00:00.094Z")]
        public DateTime StartTime { get; set; }
        [DefaultValue("2026-10-15T10:00:00.094Z")]
        public DateTime EndTime { get; set; }
        [DefaultValue(1)]
        public int StudyRoomId { get; set; }
        [DefaultValue(1)]
        public int UserId { get; set; }
    }
}