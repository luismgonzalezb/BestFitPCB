using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BestFitBusinessLayer.Models.Mapping
{
    public class arraySpacingMap : EntityTypeConfiguration<arraySpacing>
    {
        public arraySpacingMap()
        {
            // Primary Key
            this.HasKey(t => t.arraySpacingId);

            // Properties
            this.Property(t => t.profileId)
                .IsRequired();

            this.Property(t => t.arraySpacingName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("arraySpacing");
            this.Property(t => t.arraySpacingId).HasColumnName("arraySpacingId");
            this.Property(t => t.profileId).HasColumnName("profileId");
            this.Property(t => t.min).HasColumnName("min");
            this.Property(t => t.max).HasColumnName("max");
            this.Property(t => t.std).HasColumnName("std");
            this.Property(t => t.arraySpacingName).HasColumnName("arraySpacingName");
        }
    }
}