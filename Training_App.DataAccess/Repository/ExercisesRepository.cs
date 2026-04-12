using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Training_App.DataAccess.Entity;
using Training_App.Domain.Models;
using Training_App.Domain.Abstraction;

namespace Training_App.DataAccess.Repository;

public class ExerciseRepository : IExerciseRepository
{
    private readonly TrainingAppDbContext _context;

    public ExerciseRepository(TrainingAppDbContext context)
    {
        _context = context;
    }

    private Result<Exercise> MapToDomain(ExerciseEntity entity)
    {
        var muscles = entity.ExerciseMuscles
            .Select(em =>
            {
                var muscle = Muscle.Load(em.Muscle.Id, em.Muscle.Name, em.Muscle.CreatedByUserId);
                return ExerciseMuscle.Create(em.IsPrimary, muscle.Value).Value;
            })
            .ToList();

        var exercise = Exercise.Load(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.CreatedByUserId);

        exercise.Value.AddMuscles(muscles);

        return exercise;
    }

    public async Task<Result<IReadOnlyList<Exercise>>> GetAll()
    {
        var entities = await _context.Exercises
            .Include(e => e.ExerciseMuscles)
                .ThenInclude(em => em.Muscle)
            .AsNoTracking()
            .ToListAsync();

        var exercises = entities
            .Select(e => MapToDomain(e).Value)
            .ToList();

        return Result.Success<IReadOnlyList<Exercise>>(exercises);
    }

    public async Task<Result<IReadOnlyList<Exercise>>> Search(string query)
    {
        var entities = await _context.Exercises
            .Include(e => e.ExerciseMuscles)
                .ThenInclude(em => em.Muscle)
            .AsNoTracking()
            .Where(e => e.Name.ToLower().Contains(query.ToLower()))
            .ToListAsync();

        var exercises = entities
            .Select(e => MapToDomain(e).Value)
            .ToList();

        return Result.Success<IReadOnlyList<Exercise>>(exercises);
    }

    public async Task<Result<Exercise>> GetById(Guid id)
    {
        var entity = await _context.Exercises
            .Include(e => e.ExerciseMuscles)
                .ThenInclude(em => em.Muscle)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (entity == null)
            return Result.Failure<Exercise>($"Exercise with id {id} not found.");

        return MapToDomain(entity);
    }

    public async Task<Result<Guid>> Create(Exercise exercise)
    {
        var entity = new ExerciseEntity
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Description = exercise.Description,
            CreatedByUserId = exercise.CreatedByUserId,
            ExerciseMuscles = exercise.Muscles.Select(m => new ExerciseMusclesEntity
            {
                ExerciseId = exercise.Id,
                MuscleId = m.Muscle.Id,
                IsPrimary = m.IsPrimary
            }).ToList()
        };

        await _context.Exercises.AddAsync(entity);
        return Result.Success(entity.Id);
    }

    public async Task<Result> Update(Exercise exercise, Guid requestedByUserId)
    {
        var entity = await _context.Exercises
            .Include(e => e.ExerciseMuscles)
            .FirstOrDefaultAsync(e => e.Id == exercise.Id);

        if (entity == null)
            return Result.Failure($"Exercise with id {exercise.Id} not found.");

        if (entity.CreatedByUserId != requestedByUserId)
            return Result.Failure("You can only edit your own exercises.");

        // Оновлюємо основні поля
        _context.Entry(entity).CurrentValues.SetValues(new
        {
            exercise.Name,
            exercise.Description
        });

        // 1. ВИДАЛЕННЯ: м'язи які є в БД але їх немає в новому списку
        var incomingMuscleIds = exercise.Muscles.Select(m => m.Muscle.Id).ToList();
        var toRemove = entity.ExerciseMuscles
            .Where(em => !incomingMuscleIds.Contains(em.MuscleId))
            .ToList();

        _context.ExercisesMuscles.RemoveRange(toRemove);

        // 2. ОНОВЛЕННЯ АБО ДОДАВАННЯ
        foreach (var muscle in exercise.Muscles)
        {
            var existing = entity.ExerciseMuscles
                .FirstOrDefault(em => em.MuscleId == muscle.Muscle.Id);

            if (existing != null)
            {
                // Оновлюємо IsPrimary якщо змінився
                _context.Entry(existing).CurrentValues.SetValues(new
                {
                    muscle.IsPrimary
                });
            }
            else
            {
                // Додаємо новий зв'язок
                entity.ExerciseMuscles.Add(new ExerciseMusclesEntity
                {
                    ExerciseId = exercise.Id,
                    MuscleId = muscle.Muscle.Id,
                    IsPrimary = muscle.IsPrimary
                });
            }
        }

        return Result.Success();
    }

    public async Task<Result> Delete(Guid id, Guid requestedByUserId)
    {
        var entity = await _context.Exercises
            .FirstOrDefaultAsync(e => e.Id == id);

        if (entity == null)
            return Result.Failure($"Exercise with id {id} not found.");

        if (entity.CreatedByUserId != requestedByUserId)
            return Result.Failure("You can only delete your own exercises.");

        _context.Exercises.Remove(entity);
        return Result.Success();
    }
}