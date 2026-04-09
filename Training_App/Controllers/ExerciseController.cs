// using Microsoft.AspNetCore.Mvc;
// using Training_App.Api.Contracts;
// using Training_App.Application.Services;
// using Training_App.Domain.Models;
//
// namespace Training_App.Controllers;
// [ApiController]
// [Route("api/[controller]")]
// public class ExerciseController: ControllerBase
// {
//     private readonly IExercisesService _exercisesService;
//
//     public ExerciseController(IExercisesService exercisesService)    
//     {
//         _exercisesService = exercisesService;
//     }
//
//     [HttpGet]
//     public async Task<ActionResult<List<ExerciseResponse>>> GetAllExercises()
//     {
//         var exercises = await _exercisesService.GetAllExercises();
//         var response = exercises.Select(e => new ExerciseResponse(
//             e.Id,
//             e.Name,
//             e.Muscles,
//             e.CountOfBasicSets,
//             e.CountOfWurmUpSets,
//             e.Weight));
//
//         return Ok(response); 
//     }
//
//     [HttpGet("{id}")]
//     public async Task<ActionResult<ExerciseResponse>> GetExerciseById(Guid id)
//     {
//         var exercise = await _exercisesService.GetExerciseById(id);
//         if (exercise == null)
//         {
//             return NotFound();
//         }
//         var response = new ExerciseResponse(
//             exercise.Id,
//             exercise.Name,
//             exercise.Muscles,
//             exercise.CountOfBasicSets,
//             exercise.CountOfWurmUpSets,
//             exercise.Weight);
//         return Ok(response);
//     }
//
//     [HttpPost]
//     public async Task<ActionResult<Guid>> CreateExercise([FromBody] ExerciseRequest request)
//     {
//         var (exercise, error) = Exercise.Create(
//             Guid.NewGuid(),
//             request.Name,
//             request.Muscles,
//             request.CountOfBasicSets,
//             request.CountOfWurmUpSets,
//             request.Weight);
//         if (!string.IsNullOrEmpty(error))
//         {
//             return BadRequest(error);
//         }
//
//         var exerciseid = await _exercisesService.CreateExercise(exercise);
//
//         return Ok(exerciseid);
//     }
//
//     [HttpPut("{id:guid}")]
//     public async Task<ActionResult<Guid>> UpdateExercise(Guid id, [FromBody] ExerciseRequest request)
//     {
//          var updatedId = await _exercisesService.UpdateExercise(id, request.Name, request.Muscles, request.CountOfBasicSets, request.CountOfWurmUpSets, request.Weight);
//         return updatedId;
//     }
//
//     [HttpDelete("{id:guid}")]
//     public async Task<ActionResult<Guid>> DeleteExercise(Guid id)
//     {
//         return await _exercisesService.DeleteExercise(id);
//     }
//
//
//
// }
//
