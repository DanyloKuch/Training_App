using CSharpFunctionalExtensions;
using Training_App.Domain.Models;

namespace Training_App.DataAccess.Repository
{
    public interface ITrainingRepository
    {
        Task<Result<Guid>> Create(Training training);
        Task<Result> Delete(Guid Id);
        Task<Result<IReadOnlyList<Training>>> GetAll();
        Task<Result<Training>> GetById(Guid id);
        Task<Result<Guid>> Update(Guid id, string typename, DateTime date, DateTime endTime);
    }
}