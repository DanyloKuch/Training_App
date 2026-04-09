using AutoMapper;
using Training_App.Application.Contracts;
using Training_App.Domain.Models;

namespace Training_App.Application.Mapping
{
    public class TrainingMappingProfile : Profile
    {
        public TrainingMappingProfile()
        {
            CreateMap<ExerciseSet, ExerciseSetResponse>()
                .ConstructUsing(src => new ExerciseSetResponse(
                    src.Id,
                    src.TrainingId,
                    src.ExerciseId,
                    src.Weight,
                    src.Reps,
                    src.SetNumber,
                    src.SetType
                ));

            CreateMap<Training, TrainingResponse>()
                .ConstructUsing((src, ctx) => new TrainingResponse(
                    src.Id,
                    src.UserId,
                    src.Typename,
                    src.ScheduledDate,
                    src.StartTime,
                    src.EndTime,
                    src.Status,
                    src.Notes,
                    ctx.Mapper.Map<IReadOnlyCollection<ExerciseSetResponse>>(src.Sets) // ← маппить сети
                ));
        }
    }
}