using System.Data.Entity.ModelConfiguration;

namespace Logger.Example.Models.Mapping
{
    public class AllocationMap : EntityTypeConfiguration<Allocation>
    {
        public AllocationMap()
        {
            // Primary Key
            this.HasKey(t => t.AllocationID);

            // Properties
            this.Property(t => t.AreaAllocate)
                .HasMaxLength(100);

            this.Property(t => t.Criteria)
                .HasMaxLength(100);

            this.Property(t => t.ProgramCode)
                .HasMaxLength(250);

            this.Property(t => t.NoteCalculate)
                .HasMaxLength(250);

            this.Property(t => t.Note)
                .HasMaxLength(250);

            this.Property(t => t.Participant)
                .HasMaxLength(250);

            this.Property(t => t.Part)
                .HasMaxLength(250);


            // Mapping
            this.ToTable("Allocations");
            this.Property(t => t.AllocationID).HasColumnName("AllocationID");
            this.Property(t => t.PaymentID).HasColumnName("PaymentID");
            this.Property(t => t.ClaimID).HasColumnName("ClaimID");
            this.Property(t => t.AreaAllocate).HasColumnName("AreaAllocate");
            this.Property(t => t.Criteria).HasColumnName("Criteria");
            this.Property(t => t.FafDate).HasColumnName("FafDate");
            this.Property(t => t.ActualDate).HasColumnName("ActualDate");
            this.Property(t => t.AllocateAmount).HasColumnName("AllocateAmount");
            this.Property(t => t.CalculateAmount).HasColumnName("CalculateAmount");
            this.Property(t => t.ActualAmount).HasColumnName("ActualAmount");
            this.Property(t => t.TimeAllocate).HasColumnName("TimeAllocate");
            this.Property(t => t.ProgramCode).HasColumnName("ProgramCode");
            this.Property(t => t.NoteCalculate).HasColumnName("NoteCalculate");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Participant).HasColumnName("Participant");
            this.Property(t => t.Part).HasColumnName("Part");
        }
    }
}
