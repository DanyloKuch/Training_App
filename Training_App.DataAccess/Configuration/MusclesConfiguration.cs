using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration;

public class MusclesConfiguration : IEntityTypeConfiguration<MusclesEntity>
{
    public void Configure(EntityTypeBuilder<MusclesEntity> builder)
    {
        builder.ToTable("Muscles");
        
        builder.HasKey(x => x.Id);
        
        builder.HasMany(m => m.ExerciseMuscles)
            .WithOne(e => e.Muscle)
            .HasForeignKey(m => m.MuscleId);
    }
    
}