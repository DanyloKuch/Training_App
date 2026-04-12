using CSharpFunctionalExtensions;
using Training_App.Application.Contracts;

namespace Training_App.Application.Interfaces;

public interface IExerciseService
{
    Task<Result<IReadOnlyList<ExerciseResponse>>> GetAll();
    Task<Result<IReadOnlyList<ExerciseResponse>>> Search(string query);
    Task<Result<ExerciseResponse>> GetById(Guid id);
    Task<Result<Guid>> Create(ExerciseRequest request);
    Task<Result<ExerciseResponse>> Update(Guid exerciseId,ExerciseRequest exercise);
    Task<Result> Delete(Guid id);
}