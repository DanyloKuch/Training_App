using Training_App.Domain.Enum;

namespace Training_App.Application.Contracts;

public record TrainingResponse(
    Guid Id,
    Guid UserId,
    string typename, 
    DateTime ScheduledDate, 
    DateTime StartTime,
    DateTime EndTime,
    Status Status,
    string Notes,
    IReadOnlyCollection<ExerciseSetResponse> Sets
);

public record TrainingRequest(
    string Typename,
    DateTime ScheduledDate, 
    DateTime StartTime,
    DateTime EndTime,
    Status Status,
    string Notes,
    IReadOnlyCollection<ExerciseSetRequest> ExerciseSets
);

public record UpdateTrainingRequest(
    string Typename,
    DateTime ScheduledDate,
    DateTime StartTime,
    DateTime EndTime,
    Status Status,
    string Notes,
    IReadOnlyCollection<UpdateExerciseSetRequest> ExerciseSets 
);