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

        builder.HasOne(em => em.Exercise)
            .WithMany(e => e.ExerciseMuscles)
            .HasForeignKey(em => em.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);  // видаляємо зв'язки якщо вправа видалена

        builder.HasOne(em => em.Muscle)
            .WithMany(m => m.ExerciseMuscles)
            .HasForeignKey(em => em.MuscleId)
            .OnDelete(DeleteBehavior.Restrict);  // не можна видалити м'яз якщо є вправи
    }
}