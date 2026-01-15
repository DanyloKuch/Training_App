using Microsoft.AspNetCore.Mvc;
using Training_App.Api.Contracts;
using Training_App.Application.Services;

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
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTrainingById(Guid id)
        {
            var training = await _trainingService.GetTrainingById(id);
            
            return Ok(training);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraining([FromBody] TrainingRequest training)
        {
            var result = await _trainingService.CreateTraining(training);


            //if (!result.IsSuccess)
            //{
            //    return BadRequest(result.Error);
            //}
            return result.IsSuccess(result)
                ? Ok()
                : BadRequest(result.Error);
        }
    }
}
