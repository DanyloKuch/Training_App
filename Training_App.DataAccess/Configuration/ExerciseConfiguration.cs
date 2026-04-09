using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<ExerciseEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseEntity> builder)
        {
            builder.ToTable("Exercises");
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.ExerciseSets)
                .WithOne(e => e.Exercise)
                .HasForeignKey(e => e.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.ExerciseMuscles)
                .WithOne(e => e.Exercise)
                .HasForeignKey(e => e.ExerciseId);
        }
    }
}
