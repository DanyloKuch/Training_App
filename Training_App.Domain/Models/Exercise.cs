using System;
using CSharpFunctionalExtensions;


namespace Training_App.Domain.Models
{
    public class Exercise
    { 
        private Guid Id { get; }
        private Guid UserId { get; }
        private string Name { get; }
        private string Description { get; }
        private Guid CreatedByUserId { get; }
        private IReadOnlyCollection<ExerciseMuscle> Muscle { get; }
        private Exercise(Guid id, Guid userId, string name, string description, Guid createdByUserId)
        {
            Id = id;
            Name = name;
            Description = description;  
            CreatedByUserId = createdByUserId;
            UserId = userId;
        }

        public static Result<Exercise> Create(Guid id, Guid userId, string name, string description, Guid createdByUserId)
        {
            return Result.Success<Exercise>(new Exercise(userId, userId, name, description, createdByUserId));
        }
    }
}
