using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models.Mapping
{
    public class PaymentMap : EntityTypeConfiguration<Payment>
    {
        public PaymentMap()
        {
            // Primary key
            this.HasKey(t => t.PaymentID);

            // Properties
            this.Property(t => t.InvoiceCode)
                .HasMaxLength(50);

            this.Property(t => t.NoteCalculate)
                .HasMaxLength(250);

            this.Property(t => t.Note)
                .HasMaxLength(250);

            // Mapping
            this.ToTable("Payments");
            this.Property(t => t.PaymentID).HasColumnName("PaymentID");
            this.Property(t => t.ClaimID).HasColumnName("ClaimID");
            this.Property(t => t.InvoiceCode).HasColumnName("InvoiceCode");
            this.Property(t => t.PaymentDate).HasColumnName("PaymentDate");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.VendorPayment).HasColumnName("VendorPayment");
            this.Property(t => t.NoteCalculate).HasColumnName("NoteCalculate");
            this.Property(t => t.Note).HasColumnName("Note");
        }
    }
}
