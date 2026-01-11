using Microsoft.AspNetCore.Http.HttpResults;
using Training_App.DataAccess.Repository;
using Training_App.Domain.Models;

namespace Training_App.Application.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly IExercisesRepository _exercisesRepository;

        public ExercisesService(IExercisesRepository exercisesRepository)
        {
            _exercisesRepository = exercisesRepository;
        }

        public async Task<List<Exercise>> GetAllExercises()
        {
            return await _exercisesRepository.Get();
        }

        public async Task<Guid> CreateExercise(Exercise exercise)
        {
            return await _exercisesRepository.Create(exercise);
        }

        public async Task<Guid> UpdateExercise(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight)
        {
            return await _exercisesRepository.Update(id, name, muscles, countOfBasicSets, countOfWurmUpSets, weight);
        }

        public async Task<Guid> DeleteExercise(Guid id)
        {
            return await _exercisesRepository.Delete(id);
        }

        public async Task<Exercise?> GetExerciseById(Guid id)
        {
            return await _exercisesRepository.GetById(id);
        }
    }
}
