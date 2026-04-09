using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration;

public class ExerciseMusclesConfiguration : IEntityTypeConfiguration<ExerciseMusclesEntity>
{
    public void Configure(EntityTypeBuilder<ExerciseMusclesEntity> builder)
    {
        builder.ToTable("ExerciseMuscles");
        
        builder.HasKey(e => new { e.ExerciseId, e.MuscleId });
    }
    
}