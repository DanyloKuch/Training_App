using CSharpFunctionalExtensions;
using System;


namespace Training_App.Models
{
    public class Exercise
    {
        private Exercise(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight)
        {
            Id = id;
            Name = name;
            Muscles = muscles;
            CountOfBasicSets = countOfBasicSets;
            CountOfWurmUpSets = countOfWurmUpSets;
            Weight = weight;
        }
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Muscles { get; } = string.Empty;
        public int CountOfBasicSets { get; }
        public int CountOfWurmUpSets { get; }
        public decimal Weight { get; } 

        public static Result<Exercise> Create(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Exercise>($"'{nameof(Exercise)} cannot be null or empty");
            }
            var exercise = new Exercise(id, name, muscles, countOfBasicSets, countOfWurmUpSets, weight);
            return Result.Success<Exercise>(exercise);
        }
    }
}
