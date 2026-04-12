using AutoMapper;
using Training_App.Application.Contracts;
using Training_App.Domain.Models;

namespace Training_App.Application.Mapping;

public class ExerciseMappingProfile : Profile
{
    public  ExerciseMappingProfile()
    {
        CreateMap<ExerciseMuscle, ExerciseMuscleResponse>()
            .ConstructUsing(src => new ExerciseMuscleResponse(
                src.Muscle.Id,
                src.Muscle.Name,
                src.IsPrimary
            ));
        CreateMap<Exercise, ExerciseResponse>()
            .ConstructUsing((src, ctx) => new ExerciseResponse(
                src.Id,
                src.Name,
                src.Description,
                ctx.Mapper.Map<IReadOnlyCollection<ExerciseMuscleResponse>>(src.Muscles)
                ));
    }
    
}