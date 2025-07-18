namespace StudySphere.API.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Foreign Key i Navigation property 
        public int UserId { get; set; }
        public User User { get; set; }
        public int StudyRoomId { get; set; } 
        public StudyRoom StudyRoom { get; set; } 
    }
}
