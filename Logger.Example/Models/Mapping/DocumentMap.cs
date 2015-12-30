using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models.Mapping
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            this.HasKey(t => t.DocumentID);

            //this.Property(t => t.ReferenceName)
            //    .HasMaxLength(255);

            this.Property(t => t.FileName)
                .HasMaxLength(255);

            this.Property(t => t.FileType)
                .HasMaxLength(255);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Note)
                .HasMaxLength(255);

            // Mapping
            this.ToTable("Documents");
            this.Property(t => t.DocumentID).HasColumnName("ID");
            this.Property(t => t.ReferenceID).HasColumnName("ReferenceID");
            // this.Property(t => t.ReferenceName).HasColumnName("ReferenceName");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FileType).HasColumnName("FileType");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Note).HasColumnName("Note");

            this.Property(t => t.UploadBy).HasColumnName("UploadBy");
            this.Property(t => t.UploadTime).HasColumnName("UploadTime");
        }
    }
}
