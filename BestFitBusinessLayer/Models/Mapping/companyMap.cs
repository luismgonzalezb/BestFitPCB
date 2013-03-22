using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BestFitBusinessLayer.Models.Mapping
{
    public class companyMap : EntityTypeConfiguration<company>
    {
        public companyMap()
        {
            // Primary Key
            this.HasKey(t => t.companyId);

            // Properties
            this.Property(t => t.companyName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.companyPhone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.companyEmail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.companyAddress)
                .IsRequired()
                .HasMaxLength(249);

            this.Property(t => t.companyAddress2)
                .IsRequired()
                .HasMaxLength(249);

            this.Property(t => t.companyCity)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.companyState)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.companyCountry)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("companies");
            this.Property(t => t.companyId).HasColumnName("companyId");
            this.Property(t => t.companyName).HasColumnName("companyName");
            this.Property(t => t.companyPhone).HasColumnName("companyPhone");
            this.Property(t => t.companyEmail).HasColumnName("companyEmail");
            this.Property(t => t.companyAddress).HasColumnName("companyAddress");
            this.Property(t => t.companyAddress2).HasColumnName("companyAddress2");
            this.Property(t => t.companyCity).HasColumnName("companyCity");
            this.Property(t => t.companyState).HasColumnName("companyState");
            this.Property(t => t.companyCountry).HasColumnName("companyCountry");
        }
    }
}