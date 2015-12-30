using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models.Mapping
{
    public class ClaimMap : EntityTypeConfiguration<Claim>
    {
        public ClaimMap()
        {
            // Primary Key
            this.HasKey(t => t.ClaimID);

            // Properties
            this.Property(t => t.EditStatus)
                .HasMaxLength(50);

            this.Property(t => t.ClaimType)
                .HasMaxLength(50);

            this.Property(t => t.BuName)
                .HasMaxLength(255);

            this.Property(t => t.ParticipantClaim)
                .HasMaxLength(255);

            this.Property(t => t.UnitClaim)
                .HasMaxLength(255);

            this.Property(t => t.ReceiptAccount)
                .HasMaxLength(255);

            this.Property(t => t.FtgProgramCode)
                .HasMaxLength(255);

            this.Property(t => t.VendorProgramCode)
                .HasMaxLength(255);

            this.Property(t => t.ProgramName)
                .HasMaxLength(255);

            this.Property(t => t.ProgramType)
                .HasMaxLength(255);

            this.Property(t => t.PaymentMethod)
                .HasMaxLength(255);

            this.Property(t => t.RequireClaimDoc);

            this.Property(t => t.VendorName)
                .HasMaxLength(255);

            this.Property(t => t.ProductLine)
                .HasMaxLength(255);

            this.Property(t => t.Note)
                .HasMaxLength(255);

            this.Property(t => t.ProgramContent)
                .HasMaxLength(255);

            this.Property(t => t.CurrencyUnit)
                .HasMaxLength(255);

            this.Property(t => t.ExchangeRate);

            this.Property(t => t.ClaimItem)
                .HasMaxLength(255);

            this.Property(t => t.EmailsReceiver)
                .HasMaxLength(255);

            // Mapping
            this.ToTable("Claims");
            this.Property(t => t.ClaimID).HasColumnName("ClaimID");
            this.Property(t => t.RequestID).HasColumnName("RequestID");
            this.Property(t => t.StatusID).HasColumnName("Status");
            this.Property(t => t.EditStatus).HasColumnName("EditStatus");
            this.Property(t => t.ClaimType).HasColumnName("ClaimType");
            this.Property(t => t.BuName).HasColumnName("BUName");
            this.Property(t => t.ParticipantClaim).HasColumnName("ParticipantClaim");
            this.Property(t => t.UnitClaim).HasColumnName("UnitClaim");
            this.Property(t => t.ReceiptAccount).HasColumnName("ReceiptAccount");
            this.Property(t => t.FtgProgramCode).HasColumnName("FTGProgramCode");
            this.Property(t => t.VendorProgramCode).HasColumnName("VendorProgramCode");
            this.Property(t => t.ProgramName).HasColumnName("ProgramName");
            this.Property(t => t.ProgramType).HasColumnName("ProgramType");
            this.Property(t => t.PaymentMethod).HasColumnName("PaymentMethod");
            this.Property(t => t.RequireClaimDoc).HasColumnName("RequireClaimDoc");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.ProductLine).HasColumnName("ProductLine");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.ClaimDeadlineDate).HasColumnName("ClaimDeadlineDate");
            this.Property(t => t.PrePaid).HasColumnName("PrePaid");
            this.Property(t => t.PreviousStatus).HasColumnName("PreviousStatus");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.ProgramContent).HasColumnName("ProgramContent");
            this.Property(t => t.CurrencyUnit).HasColumnName("CurrencyUnit");
            this.Property(t => t.ExchangeRate).HasColumnName("ExchangeRate");
            this.Property(t => t.ClaimItem).HasColumnName("ClaimItem");
            this.Property(t => t.EmailsReceiver).HasColumnName("EmailsReceiver");
            this.Property(t => t.PromiseAmount).HasColumnName("PromiseAmount");
            this.Property(t => t.PromiseDate).HasColumnName("PromiseDate");
            this.Property(t => t.SubmitClaimAmount).HasColumnName("SubmitClaimAmount");
            this.Property(t => t.SubmitClaimDate).HasColumnName("SubmitClaimDate");
            this.Property(t => t.VendorConfirmAmount).HasColumnName("VendorConfirmAmount");
            this.Property(t => t.VendorConfirmDate).HasColumnName("VendorConfirmDate");
            this.Property(t => t.CurrentAvailableAmount).HasColumnName("CurrentAvailableAmount");
            this.Property(t => t.CurrentAvailableDate).HasColumnName("CurrentAvailableDate");

            this.Property(t => t.CreateBy).HasColumnName("CreateBy");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");

            this.Property(t => t.LastEditBy).HasColumnName("LastEditBy");
            this.Property(t => t.LastEditTime).HasColumnName("LastEditTime");

            this.Property(t => t.LastApproveBy).HasColumnName("LastApproveBy");
            this.Property(t => t.LastApproveTime).HasColumnName("LastApproveTime");
        }
    }
}
