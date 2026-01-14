//using CSharpFunctionalExtensions;
using System;


namespace Training_App.Domain.Models
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

        public static (Exercise Exercise, string Error) Create(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                return (null!, $"'{nameof(Exercise)} cannot be null or empty");
            }
            var exercise = new Exercise(id, name, muscles, countOfBasicSets, countOfWurmUpSets, weight);

            return (exercise, error);
        }
    }
}
