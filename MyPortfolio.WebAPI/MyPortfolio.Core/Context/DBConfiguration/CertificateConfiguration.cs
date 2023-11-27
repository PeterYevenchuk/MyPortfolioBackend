using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Core.Certificates;

namespace MyPortfolio.Core.Context.DBConfiguration;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.ToTable("Certificates", "public");

        builder.HasKey(c => c.CertificateID); 
        builder.Property(c => c.CertificateID)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(c => c.CertificatePdf)
            .HasColumnType("bytea");

        builder.Property(c => c.AboutMeID); 

        builder.HasOne(c => c.AboutMe)
            .WithMany(am => am.Certificates)
            .HasForeignKey(c => c.AboutMeID); 
    }
}
