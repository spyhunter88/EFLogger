using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models.Mapping
{
    class RequirementMap : EntityTypeConfiguration<Requirement>
    {
        public RequirementMap()
        {
            this.HasKey(t => t.RequirementID);

            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.Operation)
                .HasMaxLength(255);

            this.Property(t => t.Unit)
                .HasMaxLength(255);

            this.Property(t => t.Note)
                .HasMaxLength(1000);

            // Mapping
            this.ToTable("Requirements");
            this.Property(t => t.RequirementID).HasColumnName("RequirementID");
            this.Property(t => t.ClaimID).HasColumnName("ClaimID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Operation).HasColumnName("Operation");
            this.Property(t => t.Target).HasColumnName("Target");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.ActualAmount).HasColumnName("ActualAmount");
            this.Property(t => t.ClaimAmount).HasColumnName("ClaimAmount");
            this.Property(t => t.ReportDate).HasColumnName("ReportDate");
            this.Property(t => t.Note).HasColumnName("Note");

            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");

            this.Property(t => t.LastEditBy).HasColumnName("LastEditBy");
            this.Property(t => t.LastEditTime).HasColumnName("LastEditTime");
        }
    }
}
