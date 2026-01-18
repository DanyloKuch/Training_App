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

            builder.
                HasMany(t => t.ExerciseEntity)
                .WithMany(e => e.Training);

            builder.Property(t => t.ApplicationUserEntityId)
           .HasColumnName("ApplicationUserId");

            builder.
                HasOne(t => t.ApplicationUserEntity)
                .WithMany(au => au.TrainingEntity)
                .HasForeignKey(t => t.ApplicationUserEntityId);

        }
    }
}
