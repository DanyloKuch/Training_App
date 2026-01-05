using Microsoft.EntityFrameworkCore;
using Training_App.Models;

namespace Training_App.Repositories;

public class ExerciseRepository
{
    private readonly TrainingAppDbContext _dbContext;
    public ExerciseRepository(TrainingAppDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public async Task<List<Exercise>> Get()
    {
        var exersiceEntity = await _dbContext.Exercises
            .AsNoTracking()
            .ToListAsync();

        var exersices - exersiceEntity
            .Select(e => Exercise.Create
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _dbContext.Exercises
            .AsNoTracking()
            .FindAsync(id);
    }

    public async Task Add(Exercise exercise)
    {
        await _dbContext.Exercises.AddAsync(exercise);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Exercise exercise)
    {
        _dbContext.Exercises.Update(exercise);
        await _dbContext.SaveChangesAsync(); 
    }
}
