namespace Training_App.Application.Contracts;

public record MuscleResponse(
    Guid Id,
    string Name
);

public record ExerciseMuscleResponse(
    Guid MuscleId,
    string MuscleName,
    bool IsPrimary
);

public record ExerciseResponse(
    Guid Id,
    string Name,
    string Description,
    IReadOnlyCollection<ExerciseMuscleResponse> Muscles
);

public record ExerciseMuscleRequest(
    Guid MuscleId,
    bool IsPrimary
);

public record ExerciseRequest(
    string Name,
    string Description,
    IReadOnlyCollection<ExerciseMuscleRequest> Muscles
);