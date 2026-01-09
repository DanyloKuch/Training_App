//using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
//using Training_App.Models;

//namespace Training_App.Controllers;
//public class ExerciseController
//{
//    private readonly TrainingAppDbContext _dbContext;
//    public ExerciseController(TrainingAppDbContext context)
//    {
//        _dbContext = context;
//    }

//    public async Task<IActionResult> Get()
//    {
//        var exercises = await _dbContext.Exercises
//            .AsNoTracking()
//            .ToListAsync();
//        return Ok(exercises);
//    }
//    [HttpGet("{id}")]
//    public async Task<Exercise?> GetById(Guid id)
//    {
//        return await _dbContext.Exercises
//            .AsNoTracking()
//            .FirstOrDefaultAsync(e => e.Id == id);
//    }

//    public async Task<IActionResult> Post([FromBody] Exercise exercise)
//    {
//        exercise.Id = Guid.NewGuid();
//        _dbContext.Exercises.Add(exercise);
//        await _dbContext.SaveChangesAsync();
//        return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
//    }
//}

