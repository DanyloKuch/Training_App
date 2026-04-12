using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            
            builder.
                HasMany(au => au.Training)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
            
            builder.
                HasMany(au => au.Exercises)
                .WithOne(e => e.CreatedBy)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasMany(au => au.Muscles)
                .WithOne(m => m.CreatedBy)
                .HasForeignKey(m => m.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
