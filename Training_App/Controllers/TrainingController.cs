using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Training_App.Application.Contracts;
using Training_App.Application.Interfaces;
using Training_App.Application.Services;
using Training_App.Domain.Models;
using Scalar.AspNetCore;

namespace Training_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraining([FromBody] TrainingRequest request)
        {
           
            var result = await _trainingService.CreateTraining(request);

            if (result.IsFailure)
            {
                return BadRequest(new { error = result.Error });            }

            return Ok(result.Value);
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllTrainings()
        {
            var trainings = await _trainingService.GetAllTrainings();

            return Ok(trainings.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTrainingById(Guid id)
        {
            var training = await _trainingService.GetTrainingById(id);
            if (training.IsFailure) return NotFound(training.Error);
            
            return Ok(training.Value);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateTraining(Guid id, UpdateTrainingRequest request)
        {
            var res =  await _trainingService.UpdateTraining(id, request);
            if (res.IsFailure) return NotFound(res.Error);
            return Ok(res.Value);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteTraining(Guid id)
        {
            var res = await _trainingService.DeleteTraining(id);
            return Ok(res);
        }

    }
}
