namespace Training_App.DataAccess.Entity;

public class ExerciseMusclesEntity
{
    public Guid ExerciseId { get; set; }
    public Guid MuscleId { get; set; }
    public bool IsPrimary { get; set; }
    public ExerciseEntity Exercise { get; set; }
    public MusclesEntity Muscle { get; set; }
}