namespace Journal.DTOs
{
    public class JournalPostDto
    {
        public string Name { get; set; }
        public DateTime PrintTime { get; set; }
        public string Description { get; set; }
        public bool Display { get; set; }
    }
}
