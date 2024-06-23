using EducationAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationAPI.Configurations
{
    public class PracticeConfiguration : IEntityTypeConfiguration<Practice>
    {
        public void Configure(EntityTypeBuilder<Practice> builder)
        {
            builder
                .HasMany(e => e.TestCases)
                .WithOne(s => s.Practice)
                .HasForeignKey(s => s.PracticeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
