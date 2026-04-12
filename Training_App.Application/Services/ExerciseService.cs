using AutoMapper;
using CSharpFunctionalExtensions;
using Training_App.Application.Contracts;
using Training_App.Application.Interfaces;
using Training_App.Domain.Abstraction;
using Training_App.Domain.Models;

namespace Training_App.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;
    private readonly IMapper _mapper;

    public ExerciseService(IExerciseRepository exerciseRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUser,  IMapper mapper)
    {
        _exerciseRepository = exerciseRepository;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<ExerciseResponse>>> GetAll()
    {
        var exercises = await _exerciseRepository.GetAll();
        if (exercises.IsFailure) return Result.Failure<IReadOnlyList<ExerciseResponse>>(exercises.Error);
        
        var response = _mapper.Map<IReadOnlyList<ExerciseResponse>>(exercises.Value);
        return Result.Success(response);
    }

    public async Task<Result<Guid>> Create(ExerciseRequest request)
    {
        var userId = _currentUser.UserId;
        var exerciseDomain = Exercise.Create(
         Guid.NewGuid(),
            request.Name,
            request.Description,
            userId
        );
        if (exerciseDomain.IsFailure) return Result.Failure<Guid>(exerciseDomain.Error);
        
        var exercises = exerciseDomain.Value;
        var musclse = new List<ExerciseMuscle>();
        foreach (var mus in request.Muscles)
        {
            var muscleRes = ExerciseMuscle.Create(mus.IsPrimary, mus.MuscleId)
        }
// TODO потрібно дописати таким чином щоб muscle спочатку завантажувавсь з бази і передававсь в ExerciseMuscle.Create
    }
}