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
                HasMany(t => t.Exercise)
                .WithMany(e => e.Training);

            builder.Property(t => t.ApplicationUserId)
           .HasColumnName("ApplicationUserId");

            builder.
                HasOne(t => t.ApplicationUser)
                .WithMany(au => au.Training)
                .HasForeignKey(t => t.ApplicationUserId);

        }
    }
}
