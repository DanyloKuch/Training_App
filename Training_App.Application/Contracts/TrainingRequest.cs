using Training_App.Domain.Enum;
using Training_App.Domain.Models;

namespace Training_App.Application.Contracts
{
    public record TrainingRequest(
        string Typename,
        DateTime ScheduledDate, 
        DateTime StartTime,
        DateTime EndTime,
        Status Status,
        string Notes,
        IReadOnlyCollection<ExerciseSetRequest> ExerciseSets
    );
}
