using Training_App.Domain.Enum;

namespace Training_App.Application.Contracts;

public record ExerciseSetResponse(
    Guid Id,
    Guid TrainingId,
    Guid ExerciseId,
    decimal Weight,
    int Reps,
    int SetNumber,
    SetType SetType
);

public record ExerciseSetRequest( 
    Guid Id,
    Guid ExerciseId,
    decimal Weight,
    int Reps,
    int SetNumber,
    SetType SetType
);