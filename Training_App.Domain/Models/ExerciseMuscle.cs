using CSharpFunctionalExtensions;

namespace Training_App.Domain.Models;

public class ExerciseMuscle
{
    public bool IsPrimary { get;}
    public Muscle Muscle { get; }

    private ExerciseMuscle(bool isPrimary, Muscle muscle)
    {
        IsPrimary = isPrimary;  
        Muscle = muscle;
    }

    public static Result<ExerciseMuscle> Create(bool isPrimary, Muscle muscle)
    {
        return Result.Success<ExerciseMuscle>(new ExerciseMuscle(isPrimary, muscle));
    }
}