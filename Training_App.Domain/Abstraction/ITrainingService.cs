using CSharpFunctionalExtensions;
using Training_App.Domain.Models;

namespace Training_App.Application.Services
{
    public interface ITrainingService
    {
        Task<Result> CreateTraining(Training training);
        Task<Result> DeleteTraining(Guid id);
        Task<Result<IReadOnlyList<Training>>> GetAllTrainings();
        Task<Result<Training>> GetTrainingById(Guid id);
        Task<Result> UpdateTraining(Guid id, string typename, DateTime date, DateTime endTime);
    }
}