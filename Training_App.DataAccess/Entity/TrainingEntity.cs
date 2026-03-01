namespace Training_App.DataAccess.Entity
{
    public class TrainingEntity
    {
        public Guid Id { get; set; }
        public string Typename { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime EndTime { get; set; }
        public List<ExerciseEntity> Exercise { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUserEntity ApplicationUser { get; set; }
    }
}
