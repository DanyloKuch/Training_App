using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Training_App.DataAccess.Entity;
using Training_App.Domain.Models;


namespace Training_App.DataAccess.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingAppDbContext _context;
        public TrainingRepository(TrainingAppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IReadOnlyList<Training>>> GetAll()
        {
            var trainingEntities = await _context.Trainings
                .AsNoTracking()
                .ToListAsync();

            var trainings = trainingEntities
                .Select(t => Training.Create(t.Id, t.Typename, t.Date, t.EndTime, t.ApplicationUserId).Value)
                .ToList();

            return Result.Success<IReadOnlyList<Training>>(trainings);
        }

        public async Task<Result<Training>> GetById(Guid id)
        {
            var trainingEntity = await _context.Trainings
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainingEntity == null)
            {
                return Result.Failure<Training>($"Training with id {id} not found.");
            }

            var training = Training.Create(trainingEntity.Id, trainingEntity.Typename, trainingEntity.Date, trainingEntity.EndTime, trainingEntity.ApplicationUserId).Value;
            return Result.Success(training);
        }

        public async Task<Result<Guid>> Create(Training training)
        {
            var trainingEntity = new TrainingEntity
            {
                Id = training.Id,
                Typename = training.Typename,
                Date = training.Date,
                EndTime = training.EndTime,
                ApplicationUserId = training.ApplicationUserId
            };
            await _context.Trainings.AddAsync(trainingEntity);
            await _context.SaveChangesAsync();
            return Result.Success(trainingEntity.Id);
        }

        public async Task<Result<Guid>> Update(Guid id, string typename, DateTime date, DateTime endTime)
        {
            await _context.Trainings
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(t => t
                    .SetProperty(tr => tr.Typename, typename)
                    .SetProperty(tr => tr.Date, date)
                    .SetProperty(tr => tr.EndTime, endTime)
                );
            return Result.Success(id);
        }

        public async Task<Result> Delete(Guid Id)
        {
            await _context.Trainings
                .Where(t => t.Id == Id)
                .ExecuteDeleteAsync();
            return Result.Success();
        }
    }
}
