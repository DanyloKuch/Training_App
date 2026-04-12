using CSharpFunctionalExtensions;
using Training_App.Domain.Models;

namespace Training_App.Domain.Abstraction;

public interface IExerciseRepository
{
    Task<Result<IReadOnlyList<Exercise>>> GetAll();
    Task<Result<IReadOnlyList<Exercise>>> Search(string query);
    Task<Result<Exercise>> GetById(Guid id);
    Task<Result<Guid>> Create(Exercise exercise);
    Task<Result> Update(Exercise exercise, Guid requestedByUserId);
    Task<Result> Delete(Guid id, Guid requestedByUserId);
}