using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_App.DataAccess.Repository;
using Training_App.Domain.Models;

namespace Training_App.Application.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepositury;

        public TrainingService(ITrainingRepository trainingRepositury)
        {
            _trainingRepositury = trainingRepositury;
        }

        public async Task<Result<IReadOnlyList<Training>>> GetAllTrainings()
        {
            return await _trainingRepositury.GetAll();
        }

        public async Task<Result<Training>> GetTrainingById(Guid id)
        {
            return await _trainingRepositury.GetById(id);
        }

        public async Task<Result<Guid>> CreateTraining(Training training)
        {
            return await _trainingRepositury.Create(training);
        }

        public async Task<Result> UpdateTraining(Guid id, string typename, DateTime date, DateTime endTime)
        {
            return await _trainingRepositury.Update(id, typename, date, endTime);
        }

        public async Task<Result> DeleteTraining(Guid id)
        {
            return await _trainingRepositury.Delete(id);
        }

        Task<Result<IReadOnlyList<Training>>> ITrainingService.GetAllTrainings()
        {
            throw new NotImplementedException();
        }

        Task<Result<Training>> ITrainingService.GetTrainingById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
