using System;
using CSharpFunctionalExtensions;


namespace Training_App.Domain.Models
{
    public class Exercise
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid CreatedByUserId { get; }
        private readonly List<ExerciseMuscle> _muscles = new();
        public IReadOnlyCollection<ExerciseMuscle> Muscles => _muscles.AsReadOnly();

        private Exercise(Guid id, string name, string description, Guid createdByUserId)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedByUserId = createdByUserId;
        }

        public static Result<Exercise> Create(Guid id, string name, string description, Guid createdByUserId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Exercise>("Exercise name cannot be empty.");

            if (name.Length > 100)
                return Result.Failure<Exercise>("Exercise name cannot exceed 100 characters.");

            if (description?.Length > 500)
                return Result.Failure<Exercise>("Description cannot exceed 500 characters.");

            return Result.Success(new Exercise(id, name, description, createdByUserId));
        }

        public static Result<Exercise> Load(Guid id, string name, string description, Guid
            createdByUserId)
            => Result.Success(new Exercise(id, name, description, createdByUserId));
        
        public void AddMuscles(IEnumerable<ExerciseMuscle> muscles)
            => _muscles.AddRange(muscles);
    }
}
