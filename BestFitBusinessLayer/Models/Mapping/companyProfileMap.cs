using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BestFitBusinessLayer.Models.Mapping
{
    public class companyProfileMap : EntityTypeConfiguration<companyProfile>
    {
        public companyProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.profileId);

            // Properties
            this.Property(t => t.companyId)
                .IsRequired();

            this.Property(t => t.profileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.createDate)
                .IsRequired();

            this.Property(t => t.modifiedDate)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("companyProfile");
            this.Property(t => t.profileId).HasColumnName("profileId");
            this.Property(t => t.companyId).HasColumnName("companyId");
            this.Property(t => t.profileName).HasColumnName("profileName");
            this.Property(t => t.createDate).HasColumnName("createDate");
            this.Property(t => t.modifiedDate).HasColumnName("modifiedDate");
        }
    }
}