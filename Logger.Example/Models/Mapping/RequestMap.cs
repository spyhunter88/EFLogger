using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models.Mapping
{
    public class RequestMap : EntityTypeConfiguration<Request>
    {
        public RequestMap()
        {
            // Primary Key
            this.HasKey(t => t.RequestID);

            // Properties
            this.Property(t => t.VendorName)
                .HasMaxLength(255);

            this.Property(t => t.ProductLine)
                .HasMaxLength(255);

            this.Property(t => t.Representation)
                .HasMaxLength(255);

            this.Property(t => t.RepresentationPosition)
                .HasMaxLength(255);

            this.Property(t => t.ProgramName)
                .HasMaxLength(255);

            this.Property(t => t.Model)
                .HasMaxLength(255);

            this.Property(t => t.Unit)
                .HasMaxLength(255);

            this.Property(t => t.Rebate)
                .HasMaxLength(255);

            this.Property(t => t.Note)
                .HasMaxLength(255);

            // Mapping
            this.ToTable("Request");
            this.Property(t => t.RequestID).HasColumnName("RequestID");
            this.Property(t => t.ClaimID).HasColumnName("ClaimID");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.ProductLine).HasColumnName("ProductLine");
            this.Property(t => t.Representation).HasColumnName("Representation");
            this.Property(t => t.RepresentationPosition).HasColumnName("RepresentationPosition");
            this.Property(t => t.ProgramName).HasColumnName("ProgramName");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Model).HasColumnName("Model");
            this.Property(t => t.Target).HasColumnName("Target");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.Rebate).HasColumnName("Rebate");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.LastEditBy).HasColumnName("LastEditBy");
            this.Property(t => t.LastEditTime).HasColumnName("LastEditTime");

        }
    }
}
