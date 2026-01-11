using Training_App.Domain.Models;

namespace Training_App.DataAccess.Repository
{
    public interface IExercisesRepository
    {
        Task<Guid> Create(Exercise exercise);
        Task<Guid> Delete(Guid id);
        Task<List<Exercise>> Get();
        Task<Exercise?> GetById(Guid id);
        Task<Guid> Update(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight);
    }
}