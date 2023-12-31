using Journal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journal.Configuration
{
    public class JournalConfigurationcs : IEntityTypeConfiguration<journal>
    {
        public void Configure(EntityTypeBuilder<journal> builder)
        {
            builder.Property(p=>p.Name).IsRequired();
            builder.Property(p=>p.PrintTime).IsRequired();
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.IsDeleted).HasDefaultValue(false);
        }
    }
}
