using CSharpFunctionalExtensions;
using Training_App.Domain.Enum;

namespace Training_App.Domain.Models;

public class ExerciseSet
{
    public Guid Id { get; }
    public Guid TrainingId { get; }
    public Guid ExerciseId { get; }
    public decimal Weight { get; }
    public int Reps { get; }
    public int SetNumber { get; }
    public SetType SetType { get; }

    private ExerciseSet(Guid id, Guid trainingId, Guid exerciseId, decimal weight, int reps, int setNumber,
        SetType setType)
    {
        Id = id;
        TrainingId = trainingId;
        ExerciseId = exerciseId;
        Weight = weight;
        Reps = reps;
        SetNumber = setNumber;
        SetType = setType;
    }

    public static Result<ExerciseSet> Create(Guid id, Guid trainingId, Guid exerciseId, decimal weight, int reps,
        int setNumber, SetType setType)
    {
        return Result.Success<ExerciseSet>(new ExerciseSet(id, trainingId, exerciseId, weight, reps, setNumber, setType));
    }
}