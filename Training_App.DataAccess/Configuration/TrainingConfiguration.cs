using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration
{
    public class TrainingConfiguration : IEntityTypeConfiguration<TrainingEntity>
    {
        public void Configure(EntityTypeBuilder<TrainingEntity> builder)
        {
            
            builder.HasKey(t => t.Id);

            builder.HasMany(e => e.ExerciseSets)
                .WithOne(e => e.Training)
                .HasForeignKey(e => e.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(e => e.Status)
                .IsRequired();
        }
    }
}
