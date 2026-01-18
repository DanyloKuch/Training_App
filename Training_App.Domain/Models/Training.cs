using CSharpFunctionalExtensions;

namespace Training_App.Domain.Models
{
    public class Training
    {
        private Training(Guid id, string typename, DateTime date, DateTime endTime, Guid applicationUserId) 
        {
            Id = id;
            Typename = typename;
            Date = date;
            EndTime = endTime;
            ApplicationUserId = applicationUserId;
        }
        public Guid Id { get;}
        public Guid ApplicationUserId { get; }
        public string Typename { get;} = string.Empty;
        public DateTime Date { get; }
        public DateTime EndTime { get;}

        public static Result<Training> Create(Guid id, string typename, DateTime date, DateTime endTime, Guid applicationUserId)
        {
            if (string.IsNullOrEmpty(typename))
            {
                return Result.Failure<Training>($"'{nameof(Training)} cannot be null or empty");
            }
            var training = new Training(id, typename, DateTime.Today, DateTime.Now, applicationUserId);

            return Result.Success<Training>(training);
        }
    }
}
