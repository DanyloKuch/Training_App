using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration;

public class ExerciseSetConfiguration : IEntityTypeConfiguration<ExerciseSetEntity>
{
    public void Configure(EntityTypeBuilder<ExerciseSetEntity> builder)
    {
        builder.ToTable("ExerciseSet");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.SetType)
            .IsRequired();
    }
}