using CSharpFunctionalExtensions;
using Training_App.Domain.Enum;

namespace Training_App.Domain.Models
{
    public class Training
    {
        private Training(Guid id, Guid userId, string typename, DateTime scheduledDate, DateTime startTime, 
            DateTime endTime, Status status,
            string notes, IEnumerable<ExerciseSet> sets) 
        {
            Id = id;
            UserId = userId;
            Typename = typename;
            ScheduledDate = scheduledDate;
            StartTime = startTime;
            EndTime = endTime;
            Status = status;
            Notes = notes;
            _sets.AddRange(sets);
        }
        public Guid Id { get;}
        public Guid UserId { get; }
        public string Typename { get;} = string.Empty;
        public DateTime ScheduledDate { get; }
        public DateTime StartTime { get;}
        public DateTime EndTime { get;}
        public Status Status { get; }
        public string Notes { get; }
        public readonly List<ExerciseSet> _sets = new();
        public IReadOnlyCollection<ExerciseSet> Sets => _sets.AsReadOnly();
        public static Result<Training> Create(Guid id, Guid userId, string typename, DateTime scheduledDate, DateTime startTime,
            DateTime endTime, Status status, string notes, IEnumerable<ExerciseSet> sets)
        {
            if (string.IsNullOrEmpty(typename))
            {
                return Result.Failure<Training>($"'{nameof(Training)} cannot be null or empty");
            }

            return Result.Success<Training>(new Training(id,  userId, typename, scheduledDate, startTime, endTime, status, notes, sets));
        }
        public static Result<Training> Load(Guid id, Guid userId, string typename, DateTime scheduledDate, DateTime startTime,
            DateTime endTime, Status status, string notes, IEnumerable<ExerciseSet> sets)
        {
            return Result.Success<Training>(new Training(id,  userId, typename, scheduledDate, startTime, endTime, status, notes, sets));
        }
        
    }
}
