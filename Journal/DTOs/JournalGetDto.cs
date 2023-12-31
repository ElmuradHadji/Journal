namespace Journal.DTOs
{
    public class JournalGetDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? PrintTime { get; set; }
        public string? Description { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
