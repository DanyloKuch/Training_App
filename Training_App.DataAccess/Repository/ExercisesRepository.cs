using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Training_App.DataAccess.Entity;
using Training_App.Domain.Models;

namespace Training_App.DataAccess.Repository;

public class ExercisesRepository : IExercisesRepository
{
    private readonly TrainingAppDbContext _context;

    public ExercisesRepository(TrainingAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Exercise>> GetALl()
    {
        var exerciseEntities = await _context.Exercises
            .AsNoTracking()
            .ToListAsync();

        var exercises = exerciseEntities
            .Select(e => Exercise.Create(e.Id, e.Name, e.Muscles, e.CountOfBasicSets, e.CountOfWurmUpSets, e.Weight).Exercise)
            .ToList();

        return exercises;
    }


    public async Task<Guid> Create(Exercise exercise)
    {
        var exerciseEntity = new ExerciseEntity
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Muscles = exercise.Muscles,
            CountOfBasicSets = exercise.CountOfBasicSets,
            CountOfWurmUpSets = exercise.CountOfWurmUpSets,
            Weight = exercise.Weight
        };

        await _context.Exercises.AddAsync(exerciseEntity);
        await _context.SaveChangesAsync();

        return exerciseEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, string muscles, int countOfBasicSets, int countOfWurmUpSets, decimal weight)
    {
        await _context.Exercises
            .Where(e => e.Id == id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(ex => ex.Name, name)
                .SetProperty(ex => ex.Muscles, muscles)
                .SetProperty(ex => ex.CountOfBasicSets, countOfBasicSets)
                .SetProperty(ex => ex.CountOfWurmUpSets, countOfWurmUpSets)
                .SetProperty(ex => ex.Weight, weight)
            );

        return id;
    }

    public async Task<Exercise?> GetById(Guid id)
    {
        var exerciseEntity = await _context.Exercises
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        var exercise = Exercise.Create(
            exerciseEntity.Id,
            exerciseEntity.Name,
            exerciseEntity.Muscles,
            exerciseEntity.CountOfBasicSets,
            exerciseEntity.CountOfWurmUpSets,
            exerciseEntity.Weight
        );

        return exercise.Exercise;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Exercises
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}

