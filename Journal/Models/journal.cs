namespace Journal.Models
{
    public class journal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PrintTime { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
