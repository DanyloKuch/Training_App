using Training_App.Domain.Enum;

namespace Training_App.DataAccess.Entity;

public class ExerciseSetEntity
{
    public Guid Id { get; set; }
    public Guid TrainingId { get; set; }
    public Guid ExerciseId { get; set; }
    public Decimal Weight { get; set; }
    public int Reps { get; set; }
    public int SetNumber { get; set; }
    public SetType SetType { get; set; }
    public ExerciseEntity Exercise { get; set; }
    public TrainingEntity Training { get; set; }
}