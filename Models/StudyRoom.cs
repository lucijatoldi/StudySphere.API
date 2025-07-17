namespace StudySphere.API.Models
{
    public class StudyRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool HasWhiteboard { get; set; }
        public bool HasProjector { get; set; }
    }
}
