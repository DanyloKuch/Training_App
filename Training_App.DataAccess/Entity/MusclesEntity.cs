namespace Training_App.DataAccess.Entity;

public class MusclesEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public Guid CreatedByUserId { get; set; }
    public  UserEntity CreatedBy { get; set; }
    public ICollection<ExerciseMusclesEntity> ExerciseMuscles { get; set; }
}