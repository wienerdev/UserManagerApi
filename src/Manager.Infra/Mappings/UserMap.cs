using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");
            
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");
                
            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(180)");
            
            builder.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(80)");
        }
    }
}
