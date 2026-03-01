using Microsoft.AspNetCore.Mvc;
using Training_App.Api.Contracts;
using Training_App.Application.Services;
using Training_App.Domain.Models;

namespace Training_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTrainings()
        {
            var trainings = await _trainingService.GetAllTrainings();

            var trainingsrespone = trainings.Value.Select(t => new TrainingResponse(
                t.Id, t.Typename, t.Date, t.EndTime
                ));
            return Ok(trainingsrespone);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTrainingById(Guid id)
        {
            var training = await _trainingService.GetTrainingById(id);
            
            return Ok(training);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraining([FromBody] TrainingRequestCreate training)
        {
            var trainingmodel = Training.Create(
                Guid.NewGuid(),
                training.Typename,
                DateTime.Today,
                DateTime.Now,
                training.ApplicationUserId
                );

            if (trainingmodel.IsFailure)
            {
                return BadRequest(trainingmodel.Error);
            }

            var result = await _trainingService.CreateTraining(trainingmodel.Value);

            if (result.IsFailure)
            {
                // Повертаємо тільки рядок з помилкою, а не весь об'єкт Result
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateTraining(Guid id, TrainingRequest training)
        {
            var res =  await _trainingService.UpdateTraining(id, training.Typename, training.Date, training.EndTime);
            return Ok(res);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteTraining(Guid id)
        {
            var res = await _trainingService.DeleteTraining(id);
            return Ok(res);
        }

    }
}
