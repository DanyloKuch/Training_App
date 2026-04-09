namespace Training_App.DataAccess.Entity;

public class MusclesEnity
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public ICollection<ExerciseMusclesEntity> ExerciseMuscles { get; set; }
}