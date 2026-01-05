using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.Models;
using System;

namespace Training_App.Configuration
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(t => t.Id);

            builder.
                HasMany(t => t.Exercise)
                .WithMany(e => e.Training);

            builder.
                HasOne(t => t.ApplicationUser)
                .WithMany(au => au.Training)
                .HasForeignKey(t => t.ApplicationUserId);

        }
    }
}
