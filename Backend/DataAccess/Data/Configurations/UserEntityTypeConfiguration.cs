using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private const int _nameMaxLength = 30;

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo("user_hilo").IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(_nameMaxLength).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(_nameMaxLength).IsRequired();
            builder.Property(x => x.Age).IsRequired();
        }
    }
}
