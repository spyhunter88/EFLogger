using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models.Mapping
{
    public class ClaimStatusMap : EntityTypeConfiguration<ClaimStatus>
    {
        public ClaimStatusMap()
        {
            // Primary
            this.HasKey(t => t.StatusID);

            // Property
            this.Property(t => t.StatusName)
                .HasMaxLength(100);

            this.Property(t => t.Phase)
                .HasMaxLength(100);

            // Mapping
            this.ToTable("ClaimStatus");
            this.Property(t => t.StatusID).HasColumnName("StatusId");
            this.Property(t => t.StatusName).HasColumnName("StatusName");
            this.Property(t => t.Phase).HasColumnName("Phase");
            this.Property(t => t.Code).HasColumnName("Code");
        }
    }
}
