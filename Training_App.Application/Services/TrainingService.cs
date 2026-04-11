using System.Collections.ObjectModel;
using AutoMapper;
using CSharpFunctionalExtensions;
using Training_App.Application.Contracts;
using Training_App.Application.Interfaces;
using Training_App.Domain.Abstraction;
using Training_App.Domain.Models;

namespace Training_App.Application.Services
{
   public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly ICurrentUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(ITrainingRepository trainingRepository, ICurrentUserService userService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _trainingRepository = trainingRepository;
            _userService = userService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
         public async Task<Result<Guid>> CreateTraining(TrainingRequest training)
        {
            var userId = _userService.UserId;
            var trainingDomain = Training.Create(
                Guid.NewGuid(),
                userId,
                training.Typename,
                training.ScheduledDate,
                training.StartTime,
                training.EndTime,
                training.Status,
                training.Notes,
                new List<ExerciseSet>()
            );
            
            if (trainingDomain.IsFailure) return Result.Failure<Guid>(trainingDomain.Error);

            var trainingdomain = trainingDomain.Value;

            var exerciseSets = new List<ExerciseSet>();
            foreach (var ex in training.ExerciseSets)
            {
                var setRes = ExerciseSet.Create(Guid.NewGuid(), trainingdomain.Id, ex.ExerciseId, ex.Weight, ex.Reps, ex.SetNumber, ex.SetType);
        
                if (setRes.IsFailure) return Result.Failure<Guid>($"Set error: {setRes.Error}");
        
                exerciseSets.Add(setRes.Value);
            }
            
            trainingdomain._sets.AddRange(exerciseSets);
            var result = await _trainingRepository.Create(trainingdomain);
            if(result.IsFailure) return Result.Failure<Guid>(result.Error);
            await _unitOfWork.SaveChangesAsync();
            
            return Result.Success(result.Value);
        }
 
        public async Task<Result<IReadOnlyList<TrainingResponse>>> GetAllTrainings()
        {
            var  userId = _userService.UserId;
            var trainings = await _trainingRepository.GetAll(userId);
            var response = _mapper.Map<IReadOnlyList<TrainingResponse>>(trainings.Value);
            
            return Result.Success(response);
        }

        public async Task<Result<TrainingResponse>> GetTrainingById(Guid id)
        {
            var  userId = _userService.UserId;
            var training = await _trainingRepository.GetById(userId, id);
            
            var response = _mapper.Map<TrainingResponse>(training.Value);
            return Result.Success(response);
        }

        public async Task<Result<TrainingResponse>> UpdateTraining(Guid Id, UpdateTrainingRequest request)
        {
            var userId = _userService.UserId;
            var existingResult = await _trainingRepository.GetById(userId, Id);
    
            if (existingResult.IsFailure)
                return Result.Failure<TrainingResponse>("Training not found");
    
            var existingTraining = existingResult.Value;
    
            // Використовуємо Id з реквесту, а не генеруємо новий!
            var sets = request.ExerciseSets.Select(ex => ExerciseSet.Create(
                ex.Id == Guid.Empty ? Guid.NewGuid() : ex.Id, // Перевірка на новий сет
                Id, 
                ex.ExerciseId,
                ex.Weight, 
                ex.Reps, 
                ex.SetNumber, 
                ex.SetType).Value).ToList();

            var updatedTraining = Training.Create(
                Id,
                userId,
                request.Typename,
                request.ScheduledDate,
                request.StartTime,
                request.EndTime,
                request.Status,
                request.Notes,
                sets
            );
    
            if (updatedTraining.IsFailure)
                return Result.Failure<TrainingResponse>(updatedTraining.Error);
    
            await _trainingRepository.Update(updatedTraining.Value);
            await _unitOfWork.SaveChangesAsync();
    
            return Result.Success(_mapper.Map<TrainingResponse>(updatedTraining.Value));
        }

        public async Task<Result> DeleteTraining(Guid id)
        {
            var userId = _userService.UserId;
            var result = await _trainingRepository.Delete(userId, id);
            if (result.IsFailure) return result;
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

    }
}
