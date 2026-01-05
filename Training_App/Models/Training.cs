namespace Training_App.Models
{
    public class Training
    {
        public Guid Id { get; set; }
        public string Typename { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Exercise> Exercise { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
}
}
