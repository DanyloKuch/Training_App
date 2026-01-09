using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training_App.DataAccess.Entity;

namespace Training_App.DataAccess.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUserEntity>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserEntity> builder)
        {
            builder.HasKey(au => au.Id);

            builder.
                HasMany(au => au.TrainingEntity)
                .WithOne(t => t.ApplicationUserEntity)
                .HasForeignKey(t => t.ApplicationUserEntityId);

        }
    }
}
