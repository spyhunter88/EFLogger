using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models
{
    public partial class Payment : Entity
    {
        public Payment()
        {
            // this.Allocations = new List<Allocation>();
        }

        public int PaymentID { get; set; }
        public Int32? ClaimID { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Decimal? ExchangeRate { get; set; }
        public Decimal? VendorPayment { get; set; }
        public string NoteCalculate { get; set; }
        public string Note { get; set; }

        // Mapping
        public virtual Claim Claim { internal get; set; }
        // public virtual ICollection<Allocation> Allocations { get; set; }
    }
}
