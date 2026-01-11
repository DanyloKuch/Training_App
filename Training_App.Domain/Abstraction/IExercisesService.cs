using Training_App.Domain.Models;

namespace Training_App.Application.Services
{
    public interface IExercisesService
    {
        Task<Guid> CreateExercise(Exercise exercise);
        Task<Guid> DeleteExercise(Guid id);
        Task<List<Exercise>> GetAllExercises();
        Task<Exercise?> GetExerciseById(Guid id);
        Task<Guid> UpdateExercise(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight);
    }
}