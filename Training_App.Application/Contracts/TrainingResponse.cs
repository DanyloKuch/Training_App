using Training_App.Domain.Enum;
using Training_App.Domain.Models;

namespace Training_App.Application.Contracts
{
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
}
