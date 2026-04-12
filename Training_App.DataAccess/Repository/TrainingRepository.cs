using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Training_App.Application.Contracts;
using Training_App.DataAccess.Entity;
using Training_App.Domain.Models;
using Training_App.Domain.Abstraction;


namespace Training_App.DataAccess.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingAppDbContext _context;
        public TrainingRepository(TrainingAppDbContext context)
        {
            _context = context;
        }

        private Result<Training> MapToDomain(TrainingEntity training)
        {
            var sets = training.ExerciseSets
                .Select(s => ExerciseSet.Create(
                    s.Id,
                    s.TrainingId,
                    s.ExerciseId,
                    s.Weight,
                    s.Reps,
                    s.SetNumber,
                    s.SetType
                ).Value)
                .ToList();

            return Training.Load(
                training.Id,
                training.UserId,
                training.Typename,
                training.ScheduledDate,
                training.StartTime,
                training.EndTime,
                training.Status,
                training.Notes,
                sets);
        }

        public async Task<Result<IReadOnlyList<Training>>> GetAll(Guid userid)
        {
            var trainingEntities = await _context.Trainings
                .Include(t => t.ExerciseSets)
                .AsNoTracking()
                .Where(c => c.UserId == userid)
                .ToListAsync();
            
            var trainings = trainingEntities
                .Select(t => MapToDomain(t).Value)
                .ToList();

            return Result.Success<IReadOnlyList<Training>>(trainings);
        }

        public async Task<Result<Training>> GetById(Guid userid, Guid id)
        {
            var trainingEntity = await _context.Trainings
                .Include(t => t.ExerciseSets)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainingEntity == null)
            {
                return Result.Failure<Training>($"Training with id {id} not found.");
            }

            var entries = _context.ChangeTracker.Entries()
                .Select(e => new { e.Entity, e.State, Id = e.Property("Id").CurrentValue })
                .ToList();

            // Поставте тут точку зупинки (breakpoint)
            return MapToDomain(trainingEntity);
        }

        public async Task<Result<Guid>> Create(Training training)
        {
            var trainingEntity = new TrainingEntity
            {
                Id = training.Id,
                UserId =  training.UserId,
                Typename = training.Typename,
                ScheduledDate = training.ScheduledDate,
                StartTime = training.StartTime,
                EndTime = training.EndTime,
                Status = training.Status,
                Notes = training.Notes,
                ExerciseSets = training.Sets.Select(s => new ExerciseSetEntity{
                    Id = s.Id,
                    TrainingId = s.TrainingId, 
                    ExerciseId = s.ExerciseId,
                    Weight = s.Weight,
                    Reps = s.Reps,
                    SetNumber = s.SetNumber,
                    SetType = s.SetType
                    }).ToList()
                
            };
            await _context.Trainings.AddAsync(trainingEntity);
            return Result.Success(trainingEntity.Id);
        }

        public async Task<Result> Update(Training training)
        {
            var trainingEntity = await _context.Trainings
                .Include(t => t.ExerciseSets)
                .FirstOrDefaultAsync(t => t.Id == training.Id && t.UserId == training.UserId);
   
            if (trainingEntity == null) 
                return Result.Failure($"Training not found.");
   
            // Оновлюємо основні поля
            _context.Entry(trainingEntity).CurrentValues.SetValues(new {
                training.Typename,
                training.Status,
                training.Notes,
                training.ScheduledDate,
                training.StartTime,
                training.EndTime
            });

            // 1. ВИДАЛЕННЯ: Сети, які є в базі, але їх немає в новому списку
            var incomingIds = training.Sets.Select(s => s.Id).ToList();
            var toRemove = trainingEntity.ExerciseSets
                .Where(s => !incomingIds.Contains(s.Id))
                .ToList();
    
            _context.ExersiseSets.RemoveRange(toRemove);

            // 2. ОНОВЛЕННЯ АБО ДОДАВАННЯ
            foreach (var set in training.Sets)
            {
                var existingSet = trainingEntity.ExerciseSets
                    .FirstOrDefault(s => s.Id == set.Id);

                if (existingSet != null)
                {
                    // Оновлюємо значення існуючого сету
                    _context.Entry(existingSet).CurrentValues.SetValues(new {
                        set.ExerciseId,
                        set.Weight,
                        set.Reps,
                        set.SetNumber,
                        set.SetType
                    });
                }
                else
                {
                    // Додаємо новий сет, якого раніше не було
                    trainingEntity.ExerciseSets.Add(new ExerciseSetEntity
                    {
                        Id = set.Id == Guid.Empty ? Guid.NewGuid() : set.Id,
                        TrainingId = training.Id,
                        ExerciseId = set.ExerciseId,
                        Weight = set.Weight,
                        Reps = set.Reps,
                        SetNumber = set.SetNumber,
                        SetType = set.SetType
                    });
                }
            }

            return Result.Success();
        }

        public async Task<Result> Delete(Guid userId, Guid id)
        {
            var entity = await _context.Trainings
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (entity == null) return Result.Failure($"Training with id {id} not found, or you don't have permission to delete this training.");
            else
            {
                _context.Trainings.Remove(entity);
            }
            return Result.Success();
        }
    }
}
