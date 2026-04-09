using Training_App.Domain.Enum;
using Training_App.Domain.Models;

namespace Training_App.DataAccess.Entity
{
    public class TrainingEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Typename { get; set; } 
        public DateTime ScheduledDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Status Status { get; set; }
        public string Notes { get; set; } 
        public UserEntity User { get; set; }
        public ICollection<ExerciseSetEntity> ExerciseSets { get; set; }
        
    }
}
