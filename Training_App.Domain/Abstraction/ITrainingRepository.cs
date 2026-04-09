using CSharpFunctionalExtensions;
using Training_App.Domain.Models;

namespace Training_App.Domain.Abstraction;

public interface ITrainingRepository
{
    Task<Result<IReadOnlyList<Training>>> GetAll(Guid userid);
    Task<Result<Training>> GetById(Guid userId, Guid id);
    Task<Result<Guid>> Create(Training training);
    Task<Result> Update(Training training);
    Task<Result> Delete(Guid userId, Guid id);
}