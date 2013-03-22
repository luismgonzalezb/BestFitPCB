using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BestFitBusinessLayer.Models.Mapping
{
    public class companyUserMap : EntityTypeConfiguration<companyUser>
    {
        public companyUserMap()
        {
            // Primary Key
            this.HasKey(t => t.userId);

            // Properties
            this.Property(t => t.companyId)
                .IsRequired();

            this.Property(t => t.deleted)
                .IsRequired();

            this.Property(t => t.admin)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("companyUsers");
            this.Property(t => t.userId).HasColumnName("userId");
            this.Property(t => t.companyId).HasColumnName("companyId");
            this.Property(t => t.deleted).HasColumnName("deleted");
            this.Property(t => t.admin).HasColumnName("admin");
        }
    }
}