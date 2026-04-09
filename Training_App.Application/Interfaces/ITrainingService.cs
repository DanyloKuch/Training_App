using CSharpFunctionalExtensions;
using Training_App.Application.Contracts;
using Training_App.Domain.Models;

namespace Training_App.Application.Interfaces;

public interface ITrainingService
{
    Task<Result<IReadOnlyList<TrainingResponse>>> GetAllTrainings();
    Task<Result<IReadOnlyList<TrainingResponse>>> GetTrainingById(Guid id);
    Task<Result<Guid>> CreateTraining(TrainingRequest training);
    Task<Result<TrainingResponse>> UpdateTraining(Guid Id, TrainingRequest request);
    Task<Result> DeleteTraining(Guid id);
}